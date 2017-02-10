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


    public RaycastHit hited;
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

    /*
    void Update()
    {
        for (int i = 0; i < lastHeight.Count; i++)
        {
            
            if (Physics.Raycast(lastLand[i].transform.position, Vector3.up, out hited,MapCreator.instance.maringH,LayerMask.GetMask("SeedGroup")))
            {
                Debug.DrawRay(lastLand[i].transform.position, Vector3.up * hited.distance, Color.blue);
            }
        }
    }
    */

    public void CreateSeed()
    {
        transform.parent = MapCreator.instance.gameObject.transform;
        for (int i = 0; i < lastHeight.Count; i++)
        {
            RaycastHit hit;
            //랜덤을 돌림
            int rand = 0;
            bool made = false;
            float dist = 0;
            //여러가지 경우를 돌림
            for (int k = 0; k < MapCreator.instance.maxFindLoop; k++)
            {
                rand = Random.Range(0, MapCreator.instance.seedList.Count);

                Physics.Raycast(lastLand[i].transform.position, Vector3.up, out hit, MapCreator.instance.maringH, LayerMask.GetMask("SeedGroup"));
                dist = hit.distance;
                for (int j = 0; j < MapCreator.instance.seedList[rand].lastHeight.Count; j++)
                {
                    //탈출
                    if ((hit.collider != null && hit.distance >= MapCreator.instance.seedList[rand].lastHeight[j] + MapCreator.instance.maringH) || hit.collider == null)
                    {
                        made = true;
                        break;
                    }
                }
                //한번 더 탈출
                if (made)
                    break;
            }

            //최대 길이를 넘겼으면 끝냅니다.
            if (index <= MapCreator.instance.mapLength && made)
            {
                //시드를 생성
                GameObject temp = Instantiate(MapCreator.instance.seedList[rand].LoadPrefab());
                //시드를 싱글 톤에 등록
                MapCreator.instance.LimitCreate(temp);
                temp.GetComponent<MapSeed>().index = this.index + 1;
                //시드를 연결 시드 리스트에 등록
                childSeed.Add(temp.GetComponent<MapSeed>());
                //생성된 시드의 좌표를 현재 좌표 + 넓이, 높이 리스트 배열 값으로 대입
                temp.transform.position = new Vector2(transform.position.x + width.x, transform.position.y + lastHeight[i]);
                temp.GetComponent<MapSeed>().CreateSeed();
            }
            //마지막 끝내기 시드를 생성
            else {
                /*
                //시드를 생성
                RaycastHit hit2;
                Physics.Raycast(lastLand[i].transform.position, Vector3.up, out hit, MapCreator.instance.maringH, LayerMask.GetMask("SeedGroup"));
                Physics.Raycast(lastLand[i].transform.position, Vector3.up, out hit2, MapCreator.instance.maringH, LayerMask.GetMask("Ground"));
                if (hit.collider != null && hit2.collider != null)
                {
                    if (hit.distance > hit2.distance)
                        WallMaker(hit.distance, i);
                    else
                        WallMaker(hit2.distance, i);
                }
                else if (hit.collider != null)
                {
                    WallMaker(hit.distance, i);
                }
                else if (hit2.collider != null)
                {
                    WallMaker(hit2.distance, i);
                }
                else {

                    WallMaker(0, i);
                }
                */
            }
        }
    }

    //벽을 생성
    void WallMaker(float dist, int index)
    {
        GameObject temp = Instantiate(MapCreator.instance.wall);
        //시드를 연결 시드 리스트에 등록
        childSeed.Add(temp.GetComponent<MapSeed>());
        temp.GetComponent<MapSeed>().firstLand.transform.localScale = new Vector3(dist < 0.1f ? MapCreator.instance.maringH : dist, 1, 1.5f);
        //생성된 시드의 좌표를 현재 좌표 + 넓이, 높이 리스트 배열 값으로 대입
        temp.transform.position = new Vector2(transform.position.x + width.x, transform.position.y + lastHeight[index]);
        temp.transform.parent = MapCreator.instance.gameObject.transform;
    }


}
