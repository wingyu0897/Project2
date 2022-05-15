using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField]
    public GameObject slotPrefab;
    [SerializeField]
    public Sprite Stone;
    [SerializeField]
    public Sprite Iron;
    [SerializeField]
    public Sprite Coal;
    [SerializeField]
    public Sprite Cupper;


    public void SlotSpawner(string oreName)
    {
        if (GameObject.Find("Slot" + oreName) == null) //ore 타입과 맞는 슬롯이 없을 경우
        {
            GameObject slot = Instantiate(slotPrefab); //slot 생성
            slot.name = "Slot" + oreName; //이름 지정
            slot.GetComponent<RectTransform>().parent = GameObject.Find("Content").transform; //부모 지정 Content 오브젝트의 자식으로 생성
            slot.transform.GetChild(0).GetComponent<Text>().text = oreName; //이름 텍스트 지정
            slot.transform.GetChild(2).GetComponent<Text>().text = "1"; //개수 텍스트 지정 시작 값은 1
            slot.transform.GetChild(1).GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(oreName).GetValue(this); //슬롯 이미지 지정
        }
        else //ore 타입과 맞는 슬롯이 있을 경우
        {
            int much = int.Parse(GameObject.Find("Slot" + oreName).transform.GetChild(2).GetComponent<Text>().text); //ore 타입에 맞는 슬롯의 개수 값 조회
            GameObject.Find("Slot" + oreName).transform.GetChild(2).GetComponent<Text>().text = (much += 1).ToString(); //개수 값 += 1
        }
    }
}
