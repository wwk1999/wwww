using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChongWuList:MonoBehaviour
{
    public GameObject NameList;
    public GameObject Content;
    [NonSerialized]public ChongWuListItem ChongWuListItem1=null;
    [NonSerialized]public ChongWuListItem ChongWuListItem2=null;
    [NonSerialized]public ChongWuListItem ChongWuListItem3=null;

    public void SetChongWuList(ChongWuTable table1, ChongWuTable table2, ChongWuTable table3)
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in NameList.transform)
        {
            Destroy(item.gameObject);
        }
        if (table1 != null)
        {
            ChongWuListItem ChongWuListItem=Instantiate(Resources.Load("Prefabs/Window/ChongWuListItem"),Content.transform).GameObject().GetComponent<ChongWuListItem>();
            ChongWuListItem1 = ChongWuListItem;
            ChongWuListItem.SetChongWuListItem(table1);
            var Name=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/Name"),NameList.transform);
            switch (table1.Quality)
            {
                case 1:
                    Name.transform.Find("Name1").gameObject.SetActive(true);
                    Name.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
                case 2:
                    Name.transform.Find("Name2").gameObject.SetActive(true);
                    Name.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
                case 3:
                    Name.transform.Find("Name3").gameObject.SetActive(true);
                    Name.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
                case 4:
                    Name.transform.Find("Name4").gameObject.SetActive(true);
                    Name.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
                case 5:
                    Name.transform.Find("Name5").gameObject.SetActive(true);
                    Name.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
                case 6:
                    Name.transform.Find("Name6").gameObject.SetActive(true);
                    Name.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = table1.Name;
                    break;
            }
        }
        
        
        if (table2 != null)
        {
            ChongWuListItem ChongWuListItem=Instantiate(Resources.Load("Prefabs/Window/ChongWuListItem"),Content.transform).GameObject().GetComponent<ChongWuListItem>();
            ChongWuListItem.SetChongWuListItem(table2);
            ChongWuListItem2 = ChongWuListItem;
            var Name=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/Name"),NameList.transform);
            switch (table2.Quality)
            {
                case 1:
                    Name.transform.Find("Name1").gameObject.SetActive(true);
                    Name.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
                case 2:
                    Name.transform.Find("Name2").gameObject.SetActive(true);
                    Name.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
                case 3:
                    Name.transform.Find("Name3").gameObject.SetActive(true);
                    Name.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
                case 4:
                    Name.transform.Find("Name4").gameObject.SetActive(true);
                    Name.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
                case 5:
                    Name.transform.Find("Name5").gameObject.SetActive(true);
                    Name.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
                case 6:
                    Name.transform.Find("Name6").gameObject.SetActive(true);
                    Name.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = table2.Name;
                    break;
            }
        }
        
        
        
        if (table3 != null)
        {
            ChongWuListItem ChongWuListItem=Instantiate(Resources.Load("Prefabs/Window/ChongWuListItem"),Content.transform).GameObject().GetComponent<ChongWuListItem>();
            ChongWuListItem.SetChongWuListItem(table3);
            ChongWuListItem3 = ChongWuListItem;
            var Name=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/Name"),NameList.transform);
            switch (table3.Quality)
            {
                case 1:
                    Name.transform.Find("Name1").gameObject.SetActive(true);
                    Name.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
                case 2:
                    Name.transform.Find("Name2").gameObject.SetActive(true);
                    Name.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
                case 3:
                    Name.transform.Find("Name3").gameObject.SetActive(true);
                    Name.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
                case 4:
                    Name.transform.Find("Name4").gameObject.SetActive(true);
                    Name.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
                case 5:
                    Name.transform.Find("Name5").gameObject.SetActive(true);
                    Name.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
                case 6:
                    Name.transform.Find("Name6").gameObject.SetActive(true);
                    Name.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = table3.Name;
                    break;
            }
        }
    }
}
