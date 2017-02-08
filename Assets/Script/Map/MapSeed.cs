using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵의 시드입니다.
/// </summary>
public class MapSeed : MonoBehaviour
{
    public bool isFinish = false;
    public int index = 0;
    /// <summary>
    /// 시드의 아이디
    /// </summary>
    public int ID;
    /// <summary>
    /// 넓이
    /// </summary>
    public Vector2 width;
    /// <summary>
    /// 높이 체커
    /// </summary>
    public GameObject[] heightChecker;
    /// <summary>
    /// 처음 높이 값
    /// </summary>
    public float firstHeight;
    /// <summary>
    /// 처음 땅
    /// </summary>
    public GameObject firstLand;
    /// <summary>
    /// 마지막 높이 값
    /// </summary>
    public List<float> lastHeight;
    /// <summary>
    /// 마지막 땅
    /// </summary>
    public GameObject[] lastLand;
    /// <summary>
    /// 시드가 가지고 있는 방향 리스트입니다.
    /// </summary>
    public List<direction> directionList;

    /// <summary>
    /// 현재 시드와 연결된 시드들
    /// </summary>
    public List<MapSeed> childSeed;

    /// <summary>
    /// 시드의 방향을 지정하는 상수 값
    /// </summary>
    [SerializeField]
    public enum direction
    {
        up,
        down,
        left,
        right
    }

    public GameObject LoadPrefab()
    {
        return Resources.Load<GameObject>("3D/Seed/" + gameObject.name);
    }

    public void SetWidth()
    {
        Vector2 temp = Vector2.zero;
        float lastX = lastLand[0].transform.position.x;

        temp.x += lastX;
        temp.y = Mathf.Abs(Mathf.Abs(heightChecker[0].transform.position.y) + Mathf.Abs(heightChecker[1].transform.position.y));
        
        width = temp;
    }

    public void SetHeight()
    {
        firstHeight = firstLand.transform.position.y;
        lastHeight.RemoveRange(0, lastHeight.Count);
        for (int i = 0; i < lastLand.Length; i++)
        {
            lastHeight.Add(lastLand[i].transform.position.y);
        }
    }

    public void CreateSeed()
    {
        for (int i = 0; i < lastHeight.Count; i++)
        {
            //랜덤을 돌림
            int rand = Random.Range(0, MapCreator.instance.seedList.Count);
            //시드를 생성
            GameObject temp = Instantiate(MapCreator.instance.seedList[rand].LoadPrefab());
            //시드를 싱글 톤에 등록
            MapCreator.instance.LimitCreate(temp);
            temp.GetComponent<MapSeed>().index = this.index + 1;
            //시드를 연결 시드 리스트에 등록
            childSeed.Add(temp.GetComponent<MapSeed>());
            //생성된 시드의 좌표를 현재 좌표 + 넓이, 높이 리스트 배열 값으로 대입
            temp.transform.position = new Vector2(transform.position.x + width.x, transform.position.y + lastHeight[i]);

            if (index <= MapCreator.instance.mapLength)
            {
                temp.GetComponent<MapSeed>().CreateSeed();
            }

        }
    }

}
