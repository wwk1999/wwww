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
       
        LevelInfoConfig.init();
        AudioController.S.BGAudioSource.Play(); 
        LevelInfoConfig.InitGameLevel();
        StoreController.S.LoadStoreData();
        Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, PlayerData.S.IsQuanPing);
    }
}
