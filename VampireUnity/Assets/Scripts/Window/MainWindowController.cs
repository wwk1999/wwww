using Mysql;
using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    void Start()
    {
        WindowController.S.InitPanel();
        ResourcesConfig.Init();
        switch (GlobalPlayerAttribute.CurrentExitType)
        {
            case  ExitType.FirstGame:
                WindowController.S.MainWindow.SetActive(true);
                break;
            case ExitType.Exit:
                WindowController.S.RoleWindow.SetActive(true);
                break;
            case ExitType.Again:
                WindowController.S.SceneLoadingWindow.SetActive(true);
                break;
        }
        AudioController.S.BGAudioSource.Play(); 
    }
}
