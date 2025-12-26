using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PropInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("Resources 下的路径（不含 Resources/ 前缀），例如 Prefabs/Window/Propinfo")]
    public string resourcePath = "Prefabs/Window/Propinfo";

    [Tooltip("相对于按钮右下角的偏移（x 向右为正，y 向上为正）。右 50、下 50 => (50, -50)")]
    private Vector2 offset = new Vector2(250f, -100f);

    [Tooltip("可选：指定父物体（若为空则以 Canvas 为父）")]
    public Transform parentOverride;

    private GameObject instance;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Spawn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInstance();
    }

    public void Spawn()
    {
        if (instance != null) return;

        GameObject prefab = Resources.Load<GameObject>(resourcePath);
        if (prefab == null)
        {
            Debug.LogError($"PropInfoSpawner: 找不到 Resources/{resourcePath} 的预制体。");
            return;
        }

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("PropInfoSpawner: 找不到父级 Canvas。");
            return;
        }

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        RectTransform buttonRect = GetComponent<RectTransform>();

        instance = Instantiate(prefab, canvas.transform);
        
        RectTransform instRect = instance.GetComponent<RectTransform>();

        Vector3[] corners = new Vector3[4];
        buttonRect.GetWorldCorners(corners); // corners: 0=BL,1=TL,2=TR,3=BR for some rects; using corners[3] as bottom-right in previous code — safe to use TR depending on anchor. We'll use corners[3] to match previous behavior.

        // 使用按钮的右下角（world）转换到屏幕坐标，再加偏移（屏幕空间）
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, corners[3]);
        screenPoint += offset;

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenPoint, canvas.worldCamera, out worldPos);
        instance.transform.position = worldPos;

        // 设置父（保留世界坐标），把实例置于最上层
        instance.transform.SetParent(parentOverride != null ? parentOverride : canvas.transform, true);
        instance.transform.SetAsLastSibling();
    }

    public void ShowQuality(int quality)
    {
        instance.transform.Find("bg/quality/quality1").gameObject.SetActive(quality==1);
        instance.transform.Find("bg/quality/quality2").gameObject.SetActive(quality==2);
        instance.transform.Find("bg/quality/quality3").gameObject.SetActive(quality==3);
        instance.transform.Find("bg/quality/quality4").gameObject.SetActive(quality==4);
        instance.transform.Find("bg/quality/quality5").gameObject.SetActive(quality==5);
        instance.transform.Find("bg/quality/quality6").gameObject.SetActive(quality==6);
    }

    public void ShowName(int Name)
    {
        instance.transform.Find("bg/Name/Name1").gameObject.SetActive(Name==1);
        instance.transform.Find("bg/Name/Name2").gameObject.SetActive(Name==2);
        instance.transform.Find("bg/Name/Name3").gameObject.SetActive(Name==3);
        instance.transform.Find("bg/Name/Name4").gameObject.SetActive(Name==4);
        instance.transform.Find("bg/Name/Name5").gameObject.SetActive(Name==5);
        instance.transform.Find("bg/Name/Name6").gameObject.SetActive(Name==6);
    }

    public void SetInstance(int prop)
    {
        if (prop / 100 == 1 || prop / 100 == 2 || prop / 100 == 4)
        {
            switch (prop%100)
            {
                case 1:
                    ShowQuality(1);
                    ShowName(1);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("WhiteEdge");
                    break;
                case 2:
                    ShowQuality(2);
                    ShowName(2);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("GreenEdge");
                    break;
                case 3:
                    ShowQuality(3);
                    ShowName(3);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("BlueEdge");
                    break;
                case 4:
                    ShowQuality(4);
                    ShowName(4);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("PurpleEdge");
                    break;
                case 5:
                    ShowQuality(5);
                    ShowName(5);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("OrangeEdge");
                    break;
                case 6:
                    ShowQuality(6);
                    ShowName(6);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("RedEdge");
                    break;
            }
        }
        else
        {
            if (prop % 100 == 1 || prop % 100 == 2 || prop % 100 == 3 || prop % 100 == 4)
            {
                transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                transform.Find("bg/image/Edge").GetComponent<Animator>().Play("OrangeEdge");
            }
            else
            {
                transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                transform.Find("bg/image/Edge").GetComponent<Animator>().Play("RedEdge");
            }
        }
    }
    

    public void DestroyInstance()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }

    private void OnDisable()
    {
        DestroyInstance();
    }
}