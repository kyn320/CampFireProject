using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{

    public List<MapSeed> seedList;
    public List<GameObject> tileList;

    public int mapLength = 10;
    public float prevXPos = 0, prevHeight = 0;

    void Start()
    {
        Test();
    }

    void SetPrevValue(float x, float h)
    {
        prevXPos += x;
        prevHeight += h;
    }

    void MakeMap()
    {

        //초기 값을 설정
        for (int i = 0; i < mapLength; i++)
        {
            int rand = Random.Range(0, seedList.Count);
            int randDir = (int)seedList[rand].directionList[Random.Range(0, seedList[rand].directionList.Count)];
            print(i+"번째");
            switch (randDir)
            {
                case 0:
                    print("위");
                    break;
                case 1:
                    print("아래");
                    break;
                case 2:
                    print("왼");
                    break;
                case 3:
                    print("오른");
                    break;
                default:
                    Debug.LogError("존재하지 않는 방향 입니다. = " + randDir);
                    break;
            }
        }

    }

    void SetSeed(int rand, int dir) {
        float d = 0;
        switch (dir)
        {
            case 0:
                tileList.Add(Instantiate(seedList[rand].LoadPrefab()));
                d = prevHeight - seedList[rand].firstHeight;
                tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
                SetPrevValue(seedList[rand].width.x, seedList[rand].lastHeight);
                break;
            case 1:
                tileList.Add(Instantiate(seedList[rand].LoadPrefab()));
                d = prevHeight - seedList[rand].firstHeight;
                tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
                SetPrevValue(seedList[rand].width.x, seedList[rand].lastHeight);
                break;
            case 2:
                tileList.Add(Instantiate(seedList[rand].LoadPrefab()));
                d = prevHeight - seedList[rand].firstHeight;
                tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
                SetPrevValue(seedList[rand].width.x, seedList[rand].lastHeight);
                break;
            case 3:
                tileList.Add(Instantiate(seedList[rand].LoadPrefab()));
                d = prevHeight - seedList[rand].firstHeight;
                tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
                SetPrevValue(seedList[rand].width.x, seedList[rand].lastHeight);
                break;
        }
    }

    void Test()
    {
        //초기 값을 설정
        for (int i = 0; i < mapLength; i++)
        {
            int rand = Random.Range(0, seedList.Count);
            tileList.Add(Instantiate(seedList[rand].LoadPrefab()));
            float d = prevHeight - seedList[rand].firstHeight;
            tileList[tileList.Count - 1].transform.position = new Vector3(prevXPos, d);
            SetPrevValue(seedList[rand].width.x, seedList[rand].lastHeight);
        }
    }

}
