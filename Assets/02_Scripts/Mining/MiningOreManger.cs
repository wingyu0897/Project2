using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningOreManger : MonoBehaviour
{
    GameObject oreHp;
    Text oretext;
    [SerializeField]
    Slider hpBar;
    [SerializeField]
    GameObject mouseOn;
    GameObject lastObj;
    public float miningSpeed;
    float pickaxePower = 1;

    private void Awake()
    {
        oreHp = GameObject.Find("OreHpBar");
        oretext = GameObject.Find("OreName").GetComponent<Text>();
        hpBar.value = 1;
    }

    private void Update()
    {     
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 touchPos = new Vector2(worldPos.x, worldPos.y);
        Ray2D ray = new Ray2D(touchPos, Vector2.zero);
        RaycastHit2D rayhit = Physics2D.Raycast(ray.origin, ray.direction);


        if (rayhit.collider != null)
        {
            if (rayhit.collider.gameObject.layer == 8)
            {
                mouseOn.transform.position = rayhit.collider.gameObject.transform.position;
                mouseOn.SetActive(true);
                oreHp.SetActive(true);
                oretext.text = rayhit.collider.gameObject.tag;

                if (Input.GetMouseButtonDown(0))
                {
                    miningSpeed = GetComponent<OreSpawner>().MiningTime(true, rayhit.collider.gameObject.tag);
                    lastObj = rayhit.collider.gameObject;
                }
                else
                {

                }

                if (Input.GetMouseButton(0))
                {
                    if (rayhit.collider.gameObject != lastObj)
                    {
                        hpBar.value = 1;
                        miningSpeed = GetComponent<OreSpawner>().MiningTime(true, rayhit.collider.gameObject.tag);
                        lastObj = rayhit.collider.gameObject;
                    }
                    hpBar.value -= Time.deltaTime * miningSpeed * pickaxePower;

                    if (hpBar.value <= 0)
                    {
                        GetComponent<OreSpawner>().IsDestroyed(true, rayhit.collider.gameObject.transform.position);
                        Destroy(rayhit.collider.gameObject);
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    miningSpeed = 1;
                    hpBar.value = miningSpeed;
                }
            }
            else
            {
                miningSpeed = 1;
                hpBar.value = 1;
                mouseOn.SetActive(false);
                oreHp.SetActive(false);
                oretext.text = "";
            }
        }
        else if (!rayhit.collider)
        {
            miningSpeed = 1;
            hpBar.value = 1;
            mouseOn.SetActive(false);
            oreHp.SetActive(false);
            oretext.text = "";
        }
    }
}
