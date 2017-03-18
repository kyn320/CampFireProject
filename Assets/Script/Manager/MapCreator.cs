using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{

    //public static MapCreator instance;

    public List<MapSeed> seedRightList, seedLeftList;
   
    public GameObject wall;
    public List<GameObject> tileList;

    [Range(10,400)]
    public int mapLength = 10;
    [Range(2,10)]
    public int maxFindLoop = 3;
    [Range(0,35)]
    public float maringH = 21f;
    public float prevXPos = 0, prevHeight = 0;

    public int dir = 1;

    void Start()
    {
        StartCreateMap();
    }

    void SetPrevValue(float x, float h)
    {
        prevXPos += x;
        prevHeight += h;
    }

    
    void StartCreateMap()
    {
        int rand = Random.Range(0, seedRightList.Count);
        GameObject temp = Instantiate(seedRightList[rand].LoadPrefab());
        LimitCreate(temp);
        temp.GetComponent<MapSeed>().CreateSeed(this, dir);
    }
    

    public void LimitCreate(GameObject temp) {
        tileList.Add(temp);
    }

}
