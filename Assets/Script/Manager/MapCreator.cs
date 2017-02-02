using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{

    public List<MapSeed> seedList;
    public List<GameObject> tileList;

    public float prevXPos = 0, prevHeight = 0;

    void Start()
    {
        MakeMap();
    }

    void SetPrevValue(float x, float h)
    {
        prevXPos += x;
        prevHeight += h;
    }

    void MakeMap()
    {
        //초기 값을 설정
        SetPrevValue(seedList[0].width.x, seedList[0].lastHeight);
        tileList.Add(Instantiate(seedList[0].LoadPrefab()));
        for (int i = 1; i < seedList.Count; i++)
        {
            tileList.Add(Instantiate(seedList[i].LoadPrefab()));
            float d = prevHeight - seedList[i].firstHeight;
            tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
            SetPrevValue(seedList[i].width.x, seedList[i].lastHeight);
        }
    }
}
