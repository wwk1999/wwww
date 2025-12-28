using UnityEngine;
using Spine;
using Spine.Unity;

public class IkTool : MonoBehaviour {
    void Start() {
        Debug.LogError(111);
        var sa = GetComponent<SkeletonAnimation>();
        if (sa == null) { Debug.LogWarning("No SkeletonAnimation component"); return; }
        var skeleton = sa.Skeleton;
        Debug.Log("IK count: " + skeleton.IkConstraints.Count);
        foreach (var ik in skeleton.IkConstraints) {
            Debug.Log("IK: " + ik.Data.Name + "  target: " + (ik.Target != null ? ik.Target.Data.Name : "null"));
        }
    }
}