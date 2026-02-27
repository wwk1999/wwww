Shader "Sprites/Outline"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0

        // 描边参数
        [HDR] _OutlineColor ("描边颜色", Color) = (1,1,0,1)
        _OutlineThickness ("描边厚度", Range(0, 0.5)) = 0.05  // 扩大10倍，最大0.5
        _OutlineSoftness ("描边平滑度", Range(0, 1)) = 0.2
        _OutlineVisible ("描边可见度", Range(0, 1)) = 1.0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            Name "OUTLINE"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnityCG.cginc"
            #include "UnitySprites.cginc"

            // 描边参数
            fixed4 _OutlineColor;
            float _OutlineThickness;
            float _OutlineSoftness;
            float _OutlineVisible;
            
            float4 _MainTex_TexelSize;

            struct v2f_outline
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                float4 screenPosition : TEXCOORD2;
            };

            v2f_outline vert(appdata_full IN)
            {
                v2f_outline OUT;
                OUT.worldPosition = IN.vertex;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.screenPosition = ComputeScreenPos(OUT.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color * _RendererColor;

                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap(OUT.vertex);
                #endif

                return OUT;
            }

            fixed4 frag(v2f_outline IN) : SV_Target
            {
                fixed4 texColor = SampleSpriteTexture(IN.texcoord) * IN.color;
                float alpha = texColor.a;

                // 扩大厚度倍率 - 直接乘以一个大的系数
                float thicknessMultiplier = 50.0; // 增加厚度倍率
                float sampleDistance = _OutlineThickness * thicknessMultiplier;
                
                // 使用更大的采样半径
                float2 texelSize = _MainTex_TexelSize.xy;
                
                // 增加采样点数量和范围 - 使用更多方向和距离
                const int sampleCount = 32; // 增加到32个采样点
                float2 offsets[32];
                float weights[32];
                
                // 生成不同距离的采样点
                int index = 0;
                
                // 第一圈：近距离采样 (8个方向)
                for (int i = 0; i < 8; i++)
                {
                    float angle = i * 3.14159 * 2.0 / 8.0;
                    offsets[index] = float2(cos(angle), sin(angle)) * 1.0;
                    weights[index] = 1.0;
                    index++;
                }
                
                // 第二圈：中距离采样 (12个方向)
                for (int i = 0; i < 12; i++)
                {
                    float angle = i * 3.14159 * 2.0 / 12.0;
                    offsets[index] = float2(cos(angle), sin(angle)) * 2.0;
                    weights[index] = 0.9;
                    index++;
                }
                
                // 第三圈：远距离采样 (12个方向)
                for (int i = 0; i < 12; i++)
                {
                    float angle = i * 3.14159 * 2.0 / 12.0;
                    offsets[index] = float2(cos(angle), sin(angle)) * 3.0;
                    weights[index] = 0.7;
                    index++;
                }

                // 计算周围像素的平均透明度
                float totalWeight = 0.0;
                float maxNeighborAlpha = 0.0;
                float weightedNeighborAlpha = 0.0;
                
                for (int i = 0; i < sampleCount; i++)
                {
                    float2 offset = offsets[i] * texelSize * sampleDistance;
                    float2 sampleCoord = IN.texcoord + offset;
                    
                    // 边界检查
                    if (sampleCoord.x >= 0 && sampleCoord.x <= 1 && 
                        sampleCoord.y >= 0 && sampleCoord.y <= 1)
                    {
                        fixed4 sampleColor = SampleSpriteTexture(sampleCoord);
                        float sampleAlpha = sampleColor.a;
                        
                        // 记录最大透明度（用于外描边）
                        if (sampleAlpha > maxNeighborAlpha)
                        {
                            maxNeighborAlpha = sampleAlpha;
                        }
                        
                        weightedNeighborAlpha += sampleAlpha * weights[i];
                        totalWeight += weights[i];
                    }
                }
                
                // 使用最大透明度而不是平均，这样描边更明显
                float neighborAlpha = max(maxNeighborAlpha, 
                                         totalWeight > 0 ? weightedNeighborAlpha / totalWeight : 0);

                // 计算描边强度 - 使用更激进的算法
                float edge = neighborAlpha - alpha;
                
                // 应用平滑度
                float outline = smoothstep(0.0, _OutlineSoftness, edge);
                
                // 增强描边强度 - 使用power曲线让描边更饱满
                outline = pow(outline, 0.7); // 小于1的power会让中间调更亮
                
                // 可见度控制
                outline *= _OutlineVisible;

                // 如果描边强度足够大，进行多次采样叠加，增加厚度感
                if (outline > 0.01 && _OutlineThickness > 0.1)
                {
                    // 更大范围的二次采样
                    float sampleDistance2 = sampleDistance * 1.8;
                    float maxNeighborAlpha2 = 0.0;
                    
                    for (int j = 0; j < 16; j++)
                    {
                        float angle = j * 3.14159 * 2.0 / 16.0;
                        float2 offset = float2(cos(angle), sin(angle)) * texelSize * sampleDistance2;
                        float2 sampleCoord = IN.texcoord + offset;
                        
                        if (sampleCoord.x >= 0 && sampleCoord.x <= 1 && 
                            sampleCoord.y >= 0 && sampleCoord.y <= 1)
                        {
                            fixed4 sampleColor = SampleSpriteTexture(sampleCoord);
                            maxNeighborAlpha2 = max(maxNeighborAlpha2, sampleColor.a);
                        }
                    }
                    
                    float edge2 = maxNeighborAlpha2 - alpha;
                    float outline2 = smoothstep(0.0, _OutlineSoftness, edge2);
                    outline2 = pow(outline2, 0.7);
                    
                    // 叠加第二层描边，让厚度感更强
                    outline = max(outline, outline2 * 0.9);
                }

                // 最终颜色合成
                float finalAlpha = alpha + outline * _OutlineColor.a;
                fixed4 finalColor;
                
                if (outline > 0.01)
                {
                    if (alpha < 0.01)
                    {
                        // 纯描边区域
                        finalColor = fixed4(_OutlineColor.rgb, outline * _OutlineColor.a);
                    }
                    else
                    {
                        // 边缘混合区域
                        float3 mixedColor = lerp(texColor.rgb, _OutlineColor.rgb, outline * _OutlineColor.a * 0.8);
                        finalColor = fixed4(mixedColor, finalAlpha);
                    }
                    
                    // 增强描边颜色的亮度，让描边更明显
                    finalColor.rgb = lerp(finalColor.rgb, finalColor.rgb * 1.2, outline);
                }
                else
                {
                    finalColor = fixed4(texColor.rgb, alpha);
                }
                
                // 预乘alpha
                finalColor.rgb *= finalAlpha;
                return finalColor;
            }
            ENDCG
        }
    }
    Fallback "Sprites/Default"
}