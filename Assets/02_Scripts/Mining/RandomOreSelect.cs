using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOreSelect : MonoBehaviour
{
    [SerializeField]
    int stone = 2000;
    [SerializeField]
    int iron = 100;
    [SerializeField]
    int coal = 200;
    [SerializeField]
    int cupper = 100;
    int oresMax;
    float disOne;

    public int OreSelect(float yPos)
    {
        oresMax = stone + iron + coal + cupper;
        disOne = Random.Range(0, oresMax);

        if(yPos > -10)
        {
            return 0;
        }
        else if(yPos > -100)
        {
            if (disOne <= stone)
            {
                return 0;
            }
            else if (disOne <= stone + iron)
            {
                return 1;
            }
            else if (disOne <= stone + iron + coal)
            {
                return 2;
            }
            else if (disOne <= stone + iron + coal + cupper)
            {
                return 3;
            }
        }
        
        return 0;
    }
}
