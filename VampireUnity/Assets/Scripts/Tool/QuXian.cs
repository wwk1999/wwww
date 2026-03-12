using System;
using UnityEngine;

public class QuXian : MonoBehaviour
{
    public Transform startPoint;    // 发射点
    public Transform endPoint;      // 最终点
    public Transform controlPoint;  // 控制点（调整曲率）

    

    // 获取曲线上的点
    public Vector3 GetPoint(float t)
    {
        // 二次贝塞尔曲线公式
        Vector3 p0 = startPoint.position;
        Vector3 p1 = controlPoint.position;
        Vector3 p2 = endPoint.position;
        
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        
        Vector3 point = uu * p0 + 2 * u * t * p1 + tt * p2;
        return point;
    }
    
    // 可视化曲线
    private void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null || controlPoint == null)
            return;
            
        Gizmos.color = Color.yellow;
        int segments = 30;
        
        for (int i = 0; i < segments; i++)
        {
            float t1 = (float)i / segments;
            float t2 = (float)(i + 1) / segments;
            
            Vector3 point1 = GetPoint(t1);
            Vector3 point2 = GetPoint(t2);
            
            Gizmos.DrawLine(point1, point2);
        }
        
        // 绘制控制点连线
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(startPoint.position, controlPoint.position);
        Gizmos.DrawLine(controlPoint.position, endPoint.position);
    }

    private void Start()
    {
        OnDrawGizmos();
    }
}