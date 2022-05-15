using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreSpawner : MonoBehaviour
{
    [SerializeField]
    LayerMask voidLayer;
    [SerializeField]
    GameObject voidPrefab;
    [SerializeField]
    GameObject[] ranOre;

    GameObject voidParent;
    GameObject oreParent;
    Vector3 upGrid, downGrid, leftGrid, rightGrid;
    Vector3 orePos;
    int oreSet1, oreSet2, oreSet3, oreSet4;
    bool destroy;
    bool voidSpawn;
    string oreTag;


    private void Awake()
    {
        voidParent = GameObject.Find("VoidTiles");
        oreParent = GameObject.Find("OreTiles");
    }

    private void Update()
    {
        if (destroy == true)
        {
            GameObject.Find("SlotManager").GetComponent<SlotManager>().SlotSpawner(oreTag);
            oreSet1 = GetComponent<RandomOreSelect>().OreSelect(orePos.y);
            oreSet2 = GetComponent<RandomOreSelect>().OreSelect(orePos.y);
            oreSet3 = GetComponent<RandomOreSelect>().OreSelect(orePos.y);
            oreSet4 = GetComponent<RandomOreSelect>().OreSelect(orePos.y);

            upGrid = orePos + new Vector3(0, 1);
            downGrid = orePos - new Vector3(0, 1);
            leftGrid = orePos - new Vector3(1, 0);
            rightGrid = orePos + new Vector3(1, 0);

            if (voidSpawn == true)
            {
                GameObject voidTile = Instantiate(voidPrefab, orePos, Quaternion.identity);
                voidTile.name = $"Void {orePos.x} {orePos.y}";
                voidTile.transform.parent = voidParent.transform;
                voidSpawn = false;
            }
            if (!Physics2D.Raycast(upGrid, Vector2.zero))
            {
                GameObject Ore = Instantiate(ranOre[oreSet1], upGrid, Quaternion.identity);
                Ore.name = $"Ore {upGrid.x} {upGrid.y}";
                Ore.transform.parent = oreParent.transform;
            }
            if (!Physics2D.Raycast(downGrid, Vector2.zero))
            {
                GameObject Ore = Instantiate(ranOre[oreSet2], downGrid, Quaternion.identity);
                Ore.name = $"Ore {downGrid.x} {downGrid.y}";
                Ore.transform.parent = oreParent.transform;
            }
            if (!Physics2D.Raycast(leftGrid, Vector2.zero))
            {
                GameObject Ore = Instantiate(ranOre[oreSet3], leftGrid, Quaternion.identity);
                Ore.name = $"Ore {leftGrid.x} {leftGrid.y}";
                Ore.transform.parent = oreParent.transform;
            }
            if (!Physics2D.Raycast(rightGrid, Vector2.zero))
            {
                GameObject Ore = Instantiate(ranOre[oreSet4], rightGrid, Quaternion.identity);
                Ore.name = $"Ore {rightGrid.x} {rightGrid.y}";
                Ore.transform.parent = oreParent.transform;
            }
        }
        destroy = false;
    }

    public void IsDestroyed(bool isDestroyed, Vector3 orePosition)
    {
        destroy = isDestroyed;
        voidSpawn = isDestroyed;
        orePos = orePosition;
        
    }

    public float MiningTime(bool isClick, string tag)
    {
        if (isClick == true)
        {
            oreTag = tag;
            return GameObject.Find("MiningManager").GetComponent<OreTypeMiningTime>().Oretypeminingtime(tag);
        }
        return 1f;
    }
}
