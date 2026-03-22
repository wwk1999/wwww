using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChiBangItem1 : MonoBehaviour
{
  public ChiBangInfo ChiBangInfo;
  public Image  ChiBangImage;
  public TextMeshProUGUI Level;
  public GameObject XjContent;
  public TextMeshProUGUI Name1;
  public TextMeshProUGUI Name2;
  public TextMeshProUGUI Name3;
  public TextMeshProUGUI Name4;
  public TextMeshProUGUI Name5;
  public TextMeshProUGUI Name6;
  public Button button;
  public GameObject E;
  
  
  public void SetChiBang()
  {
    E.gameObject.SetActive(PlayerData.S.playerChiBangType==ChiBangInfo.ChiBangType);
    button.onClick.RemoveAllListeners();
    button.onClick.AddListener(() =>
    {
      ObserverModuleManager.S.SendEvent("ChiBangClick", ChiBangInfo);
    });
    ChiBangImage.sprite = ChiBangConfig.GetChiBangSprite(ChiBangInfo.ChiBangType);
    Level.text="Lv."+ChiBangInfo.Level;
    foreach (Transform item in XjContent.transform)
    {
      Destroy(item.gameObject);
    }
    for (int i = 0; i < ChiBangInfo.Xj; i++)
    {
      var xx = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/XX"),XjContent.transform);
    }
    int quality=ChiBangConfig.GetChiBangQuality(ChiBangInfo.ChiBangType);
    Name1.gameObject.SetActive(false);
    Name2.gameObject.SetActive(false);
    Name3.gameObject.SetActive(false);
    Name4.gameObject.SetActive(false);
    Name5.gameObject.SetActive(false);
    Name6.gameObject.SetActive(false);
    switch (quality)
    {
      case 1:
        Name1.gameObject.SetActive(true);
        Name1.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
      case 2:
        Name2.gameObject.SetActive(true);
        Name2.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
      case 3:
        Name3.gameObject.SetActive(true);
        Name3.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
      case 4:
        Name4.gameObject.SetActive(true);
        Name4.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
      case 5:
        Name5.gameObject.SetActive(true);
        Name5.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
      case 6:
        Name6.gameObject.SetActive(true);
        Name6.text = ChiBangConfig.GetChiBangName(ChiBangInfo.ChiBangType);
        break;
    }
  }

}
