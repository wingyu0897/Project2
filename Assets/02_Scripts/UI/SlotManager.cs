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
        if (GameObject.Find("Slot" + oreName) == null) //ore Ÿ�԰� �´� ������ ���� ���
        {
            GameObject slot = Instantiate(slotPrefab); //slot ����
            slot.name = "Slot" + oreName; //�̸� ����
            slot.GetComponent<RectTransform>().parent = GameObject.Find("Content").transform; //�θ� ���� Content ������Ʈ�� �ڽ����� ����
            slot.transform.GetChild(0).GetComponent<Text>().text = oreName; //�̸� �ؽ�Ʈ ����
            slot.transform.GetChild(2).GetComponent<Text>().text = "1"; //���� �ؽ�Ʈ ���� ���� ���� 1
            slot.transform.GetChild(1).GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(oreName).GetValue(this); //���� �̹��� ����
        }
        else //ore Ÿ�԰� �´� ������ ���� ���
        {
            int much = int.Parse(GameObject.Find("Slot" + oreName).transform.GetChild(2).GetComponent<Text>().text); //ore Ÿ�Կ� �´� ������ ���� �� ��ȸ
            GameObject.Find("Slot" + oreName).transform.GetChild(2).GetComponent<Text>().text = (much += 1).ToString(); //���� �� += 1
        }
    }
}
