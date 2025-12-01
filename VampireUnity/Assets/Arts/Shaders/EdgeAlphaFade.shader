Shader "Custom/EdgeAlphaFade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _EdgePixelWidth ("Edge Pixel Width", Float) = 50
        _AlphaReduction ("Alpha Reduction", Range(0, 1)) = 1
        _TextureSize ("Texture Size (Width, Height)", Vector) = (512, 512, 0, 0)
    }
    
    SubShader
    {
        Tags 
        { 
            "Queue" = "Transparent" 
            "RenderType" = "Transparent"
        }
        
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            
            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Color;
                float _EdgePixelWidth;
                float _AlphaReduction;
                float4 _TextureSize;
            CBUFFER_END
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            half4 frag(v2f i) : SV_Target
            {
                // 采样主纹理
                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                col *= _Color;
                
                // 计算到四个边缘的距离（UV空间，范围0-1）
                float distToLeft = i.uv.x;
                float distToRight = 1.0 - i.uv.x;
                float distToBottom = i.uv.y;
                float distToTop = 1.0 - i.uv.y;
                
                // 找到到最近边缘的距离（UV空间）
                float minDistToEdge = min(min(distToLeft, distToRight), min(distToBottom, distToTop));
                
                // 将像素宽度转换为UV空间的距离
                // edgeWidthUV = _EdgePixelWidth / textureSize
                float textureWidth = max(_TextureSize.x, _TextureSize.y);
                float edgeWidthUV = _EdgePixelWidth / textureWidth;
                
                // 计算alpha衰减因子
                // 在边缘区域内，alpha从边缘的(1 - _AlphaReduction)线性增加到edgeWidthUV处的1
                float alphaFactor = 1.0;
                if (minDistToEdge < edgeWidthUV)
                {
                    // 归一化距离：0表示在边缘，1表示在edgeWidthUV处
                    float normalizedDist = minDistToEdge / edgeWidthUV;
                    // alpha从边缘的(1 - _AlphaReduction)线性增加到edgeWidthUV处的1
                    alphaFactor = lerp(1.0 - _AlphaReduction, 1.0, normalizedDist);
                }
                
                // 应用alpha衰减
                col.a *= alphaFactor;
                
                return col;
            }
            ENDHLSL
        }
    }
    
    Fallback "Sprites/Default"
}

