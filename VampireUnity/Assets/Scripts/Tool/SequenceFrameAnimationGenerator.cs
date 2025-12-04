#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.Animations;
using UnityEngine;

/// <summary>
/// 在 Unity 顶部菜单 Tool/生成序列帧动画
/// 功能：
/// 1. 选择一张图集贴图（例如 NewAtlas.png，Multiple Sprite）
/// 2. 输入动画名和帧率
/// 3. 在当前场景中创建一个带 SpriteRenderer + Animator 的物体
/// 4. 在图集所在目录下生成对应的 AnimationClip 和 AnimatorController 资源
/// </summary>
public class SequenceFrameAnimationGenerator : EditorWindow
{
    private Texture2D atlasTexture; // 选择的图集贴图（Multiple Sprite）
    private string animationName = "NewSequenceAnim";
    private float frameRate = 12f;

    [MenuItem("Tool/生成序列帧动画")]
    private static void OpenWindow()
    {
        var window = GetWindow<SequenceFrameAnimationGenerator>("生成序列帧动画");
        window.minSize = new Vector2(380, 160);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("序列帧动画生成器", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("1. 选择一张包含序列帧 Sprite 的图集贴图（Multiple Sprite）");
        atlasTexture = (Texture2D)EditorGUILayout.ObjectField("图集 (Texture2D)", atlasTexture, typeof(Texture2D), false);

        EditorGUILayout.Space();
        animationName = EditorGUILayout.TextField("动画名 / 物体名", animationName);
        frameRate = EditorGUILayout.FloatField("帧率 (FPS)", frameRate);

        EditorGUILayout.Space();
        if (GUILayout.Button("生成序列帧动画", GUILayout.Height(30)))
        {
            Generate();
        }
    }

    private void Generate()
    {
        if (atlasTexture == null)
        {
            EditorUtility.DisplayDialog("错误", "请先选择一张图集贴图（Texture2D）。", "确定");
            return;
        }

        if (string.IsNullOrEmpty(animationName))
        {
            EditorUtility.DisplayDialog("错误", "请先输入动画名。", "确定");
            return;
        }

        if (frameRate <= 0)
        {
            EditorUtility.DisplayDialog("错误", "帧率必须大于 0。", "确定");
            return;
        }

        string atlasPath = AssetDatabase.GetAssetPath(atlasTexture);
        if (string.IsNullOrEmpty(atlasPath))
        {
            EditorUtility.DisplayDialog("错误", "无法获取图集贴图的路径。", "确定");
            return;
        }

        // 图集所在的文件夹，用于保存动画和控制器
        string folderPath = Path.GetDirectoryName(atlasPath)?.Replace("\\", "/");
        if (string.IsNullOrEmpty(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "无法解析图集所在的文件夹路径。", "确定");
            return;
        }

        // 从这张图集中获取所有子 Sprite，并按名称排序
        var allAssets = AssetDatabase.LoadAllAssetsAtPath(atlasPath);
        List<Sprite> sprites = allAssets.OfType<Sprite>().ToList();

        if (sprites == null || sprites.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "该图集中没有找到任何 Sprite，请确认导入模式为 Multiple。", "确定");
            return;
        }

        sprites = sprites
            .OrderBy(s => s.name, System.StringComparer.Ordinal)
            .ToList();

        if (sprites.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "未能在该文件夹中加载到任何 Sprite，请确认导入设置为 Sprite。", "确定");
            return;
        }

        // 创建 AnimationClip
        AnimationClip clip = CreateAnimationClip(folderPath, animationName, sprites, frameRate);
        if (clip == null)
        {
            EditorUtility.DisplayDialog("错误", "创建 AnimationClip 失败。", "确定");
            return;
        }

        // 创建 AnimatorController
        AnimatorController controller = CreateAnimatorController(folderPath, animationName, clip);
        if (controller == null)
        {
            EditorUtility.DisplayDialog("错误", "创建 AnimatorController 失败。", "确定");
            return;
        }

        // 在场景中创建 GameObject
        GameObject go = new GameObject(animationName);
        var spriteRenderer = go.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];

        var animator = go.AddComponent<Animator>();
        animator.runtimeAnimatorController = controller;

        // 选中并聚焦到新物体
        Selection.activeGameObject = go;
        SceneView.lastActiveSceneView?.FrameSelected();

        EditorUtility.DisplayDialog("完成", "序列帧动画和带 Animator 的 SpriteRenderer 已生成。", "确定");
    }

    private static AnimationClip CreateAnimationClip(string folderPath, string animName, List<Sprite> sprites, float fps)
    {
        string clipPath = Path.Combine(folderPath, animName + ".anim").Replace("\\", "/");

        AnimationClip clip = new AnimationClip
        {
            frameRate = fps
        };

        var keyframes = new ObjectReferenceKeyframe[sprites.Count];
        for (int i = 0; i < sprites.Count; i++)
        {
            keyframes[i] = new ObjectReferenceKeyframe
            {
                time = i / fps,
                value = sprites[i]
            };
        }

        var binding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        AnimationUtility.SetObjectReferenceCurve(clip, binding, keyframes);

        AssetDatabase.CreateAsset(clip, clipPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(clipPath);

        return AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
    }

    private static AnimatorController CreateAnimatorController(string folderPath, string animName, AnimationClip clip)
    {
        string controllerPath = Path.Combine(folderPath, animName + ".controller").Replace("\\", "/");

        AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath(controllerPath);
        var stateMachine = controller.layers[0].stateMachine;
        var state = stateMachine.AddState(animName);
        state.motion = clip;
        stateMachine.defaultState = state;

        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(controllerPath);

        return AssetDatabase.LoadAssetAtPath<AnimatorController>(controllerPath);
    }
}

#endif


