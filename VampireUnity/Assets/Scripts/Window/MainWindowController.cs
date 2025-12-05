using Mysql;
using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    void Start()
    {
        Debug.LogError(1111);
        WindowController.S.InitPanel();
        ResourcesConfig.Init();
        WindowController.S.MainWindow.SetActive(true);
        LevelInfoConfig.init();
        AudioController.S.BGAudioSource.Play(); 
        LevelInfoConfig.InitGameLevel();
        WeaponSourceConfig.InitWeaponSourceConfig();
        StoreController.S.LoadStoreData();
    }
    
}
