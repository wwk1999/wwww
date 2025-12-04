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
/// 1. 选择一个包含图片的文件夹
/// 2. 输入动画名和帧率
/// 3. 在当前场景中创建一个带 SpriteRenderer + Animator 的物体
/// 4. 在该文件夹下生成对应的 AnimationClip 和 AnimatorController 资源
/// </summary>
public class SequenceFrameAnimationGenerator : EditorWindow
{
    private DefaultAsset folderAsset; // 选择的文件夹（Project 视图里拖拽进来）
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

        EditorGUILayout.LabelField("1. 选择一个仅包含序列帧图片的文件夹（Project 中）");
        folderAsset = (DefaultAsset)EditorGUILayout.ObjectField("图片文件夹", folderAsset, typeof(DefaultAsset), false);

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
        if (folderAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "请先选择一个包含图片的文件夹。", "确定");
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

        string folderPath = AssetDatabase.GetAssetPath(folderAsset);
        if (string.IsNullOrEmpty(folderPath) || !AssetDatabase.IsValidFolder(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "所选对象不是有效的文件夹，请重新选择。", "确定");
            return;
        }

        // 获取该文件夹下所有图片（Texture2D），并按名称排序
        string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { folderPath });
        if (guids == null || guids.Length == 0)
        {
            EditorUtility.DisplayDialog("错误", "该文件夹下没有找到任何图片（Texture2D）。", "确定");
            return;
        }

        List<Sprite> sprites = new List<Sprite>();

        // 先把所有路径找出来再排序，保证按照文件名顺序
        var pathList = guids
            .Select(g => AssetDatabase.GUIDToAssetPath(g))
            .Where(p => !string.IsNullOrEmpty(p))
            .OrderBy(p => Path.GetFileNameWithoutExtension(p))
            .ToList();

        foreach (var path in pathList)
        {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if (sprite != null)
            {
                sprites.Add(sprite);
            }
        }

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


