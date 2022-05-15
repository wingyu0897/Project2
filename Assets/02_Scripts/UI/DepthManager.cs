using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthManager : MonoBehaviour
{
    int playerPosY;
    Text depthText;

    private void Awake()
    {
        depthText = GetComponent<Text>();
    }

    private void Update()
    {
        playerPosY = (int)Mathf.Round(GameObject.Find("Player").transform.position.y);
        
        if (playerPosY < 1)
        {
           depthText.text = "Depth : " + playerPosY;
        }
        else
        {
            depthText.text = "Depth : 0+";
        }

    }
}
