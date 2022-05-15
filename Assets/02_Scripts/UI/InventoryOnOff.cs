using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOnOff : MonoBehaviour
{
    [SerializeField]
    GameObject onBtn;
    [SerializeField]
    GameObject offBtn;
    RectTransform rectTransform;
    bool isClick = false;

    public void BtnClick(bool click)
    {
        isClick = click;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (isClick == true)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, new Vector3(620, 0, 0), 2f * Time.fixedDeltaTime);
            offBtn.SetActive(false);
            onBtn.SetActive(true);
        }
        else if (isClick == false)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, new Vector3(0, 0, 0), 2f * Time.fixedDeltaTime);
            onBtn.SetActive(false);
            offBtn.SetActive(true);
        }
    }
}
