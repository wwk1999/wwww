using System;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;


public enum CameraStatus
{
    FollowPlayer, // 跟随玩家
    MoveToBoss,   // 移动到Boss位置
    MoveToPlayer // 移动到玩家位置
}
public class CameraContraller : XSingleton<CameraContraller>
{
    //[NonSerialized] public bool FollowPlayer = true;
    [NonSerialized] float Duration = 3.0f; // 移动持续时间
    [NonSerialized] float ElapsedTime = 0f;
    [NonSerialized]public static CameraStatus CameraStatus = CameraStatus.FollowPlayer;
    [NonSerialized] public bool IsShaking = false;
    
    [NonSerialized] public float UpLimit = 11f;
    [NonSerialized] public float ButtomLimit = -10f;
    [NonSerialized] public float LeftLimit = -19f;
    [NonSerialized] public float RightLimit = 19f;


    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent(ConstKeys.CameraMoveToBoss, OnCameraMoveBegin);
    }
    

    public void CameraMovePlayer()
    {
        Vector3 targetPosition = new Vector3(GameController.S.gamePlayer.transform.position.x,
            GameController.S.gamePlayer.transform.position.y, -10);
        Vector3 startPosition = transform.position;
        ElapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(ElapsedTime / Duration);
        transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        if (transform.transform.position== new Vector3(GameController.S.gamePlayer.transform.position.x,
                GameController.S.gamePlayer.transform.position.y, -10))
        {
            CameraStatus= CameraStatus.FollowPlayer;
            ObserverModuleManager.S.SendEvent(ConstKeys.ResumePlayerCamera);
        }
    }

    public void OnCameraMoveBegin(object[] args)
    {
        //摄像机逐渐移动到(-5.5f,10,-10)
        CameraStatus= CameraStatus.MoveToBoss;
    }


    // Update is called once per frame
    void Update()
    {
        if (!IsShaking)
        {
            //摄像机跟随玩家
            if (CameraStatus == CameraStatus.FollowPlayer)
            {
                if (GameController.S.gamePlayer != null)
                {
                    transform.position = new Vector3(GameController.S.gamePlayer.transform.position.x,
                        GameController.S.gamePlayer.transform.position.y, -10);
                }
            }
            else if (CameraStatus == CameraStatus.MoveToBoss)
            {
                Vector3 targetPosition = new Vector3(-5.5f, 10, -10);
                Vector3 startPosition = transform.position;
                ElapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(ElapsedTime / Duration);
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                if (transform.transform.position == new Vector3(-5.5f, 10, -10) && !GameController.S.HaveBoss)
                {
                    // FollowPlayer = true;
                    ObserverModuleManager.S.UnRegisterEvent(ConstKeys.CameraMoveToBoss, OnCameraMoveBegin);
                }
            }
            else if (CameraStatus == CameraStatus.MoveToPlayer)
            {
                CameraMovePlayer();
            }
        }


        if (transform.position.x < LeftLimit)
            transform.position = new Vector3(-19f, transform.position.y, transform.position.z);
        if (transform.position.x > RightLimit)
            transform.position = new Vector3(19f, transform.position.y, transform.position.z);
        if (transform.position.y < ButtomLimit)
            transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
        if (transform.position.y > UpLimit)
            transform.position = new Vector3(transform.position.x, 11f, transform.position.z);
    }
    
    //摄像机抖动方法
    public void CameraShake(float duration, float magnitude)
    {
        StartCoroutine(CameraShakeCoroutine(duration, magnitude));
    }
    private System.Collections.IEnumerator CameraShakeCoroutine(float duration, float magnitude)
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(originalPosition.x+x, originalPosition.y+y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition; // 恢复原始位置
    }
}