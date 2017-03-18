using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵의 시드입니다.
/// </summary>
public class MapSeed : MonoBehaviour
{
    public int index = 0;
    /// <summary>
    /// 시드의 아이디
    /// </summary>
    public int ID;
    /// <summary>
    /// 크기 | x , y
    /// </summary>
    public Vector2 size;
    /// <summary>
    /// 마지막 높이 값
    /// </summary>
    public List<float> lastHeight;
    /// <summary>
    /// 마지막 땅
    /// </summary>
    public Transform[] lastLand;
    /// <summary>
    /// 시드가 가지고 있는 수평 방향 리스트입니다.
    /// </summary>
    public Horizontal horizontal;
    /// <summary>
    /// 시드가 가지고 있는 수직 방향 리스트입니다.
    /// </summary>
    public Vertical vertical;
    /// <summary>
    /// 현재 시드와 연결된 시드들
    /// </summary>
    public List<MapSeed> childSeed;

    /// <summary>
    /// 시드의 수평 방향을 지정하는 상수 값
    /// </summary>
    [SerializeField]
    public enum Horizontal
    {
        left,
        right
    }
    /// <summary>
    /// 시드의 수직 방향을 지정하는 상수 값
    /// </summary>
    public enum Vertical
    {
        up,
        zero,
        down
    }

    private RaycastHit hited;



    public GameObject LoadPrefab()
    {
        return Resources.Load<GameObject>("3D/Seed/" + gameObject.name);
    }


    public void SetSize()
    {
        Vector2 temp = GetComponent<BoxCollider>().size;
        size = new Vector2(Mathf.Abs(temp.x),Mathf.Abs(temp.y));
    }

    public void SetHeight()
    {
        lastHeight.RemoveRange(0, lastHeight.Count);
        for (int i = 0; i < lastLand.Length; i++) {
            lastHeight.Add(lastLand[i].position.y);
        }
    }

    
    void Update()
    {
        /*
        for (int i = 0; i < lastHeight.Count; i++)
        {

            if (Physics.Raycast(lastLand[i].transform.position, Vector3.up, out hited, width.y + MapCreator.instance.maringH, LayerMask.GetMask("SeedGroup")))
            {
                Debug.DrawRay(lastLand[i].transform.position, Vector3.up * hited.distance, Color.blue);
            }
            else {
                Debug.DrawRay(lastLand[i].transform.position, Vector3.up * (width.y + MapCreator.instance.maringH), Color.red);
            }
        }
        */
    }
    

    public void CreateSeed(MapCreator instance,int dir)
    {
        transform.parent = instance.gameObject.transform;
        Make(instance,dir);       
    }


    
    void Make(MapCreator instance,int dir) {
        //가지의 분기만큼 루프를 돕니다.
        for (int i = 0; i < lastHeight.Count; i++)
        {
            RaycastHit hit;
            int rand = 0; //dir = Random.Range(0,5);
            bool made = false;
            float dist = 0;
            //최대 찾기 횟수 만큼 루프
            for (int k = 0; k < instance.maxFindLoop; k++)
            {
                rand = Random.Range(0, instance.seedRightList.Count);
                //가지의 분기 i 번째에서 위로 레이 캐스트를 쏩니다. >> 길이 = 현재 시드의 높이 + 에디터의 추가 높이 / 시드 그룹만 체크
                Collider[] cols = Physics.OverlapBox(new Vector2(transform.position.x + size.x + instance.seedRightList[rand].GetComponent<BoxCollider>().center.x + 0.1f, transform.position.y + lastHeight[i] + instance.seedRightList[rand].GetComponent<BoxCollider>().center.y + 0.1f),instance.seedRightList[rand].GetComponent<MapSeed>().size/2 + (Vector2.up * instance.maringH),Quaternion.identity, LayerMask.GetMask("SeedGroup"));
                if (cols.Length == 0)
                {
                    made = true;
                    break;
                }
                else if(this.gameObject.name.Contains("11")){
                    print(this.gameObject+ " | " + cols[0].name);
                }
            }

            //최대 길이를 넘겼는지 체크
            if (index <= instance.mapLength && made)
            {
                //시드를 생성
                GameObject temp = Instantiate(instance.seedRightList[rand].LoadPrefab());
                //시드를 싱글 톤에 등록
                instance.LimitCreate(temp);
                //시드의 인덱스 값을 기록
                temp.GetComponent<MapSeed>().index = this.index + 1;
                //시드를 연결 시드 리스트에 등록
                childSeed.Add(temp.GetComponent<MapSeed>());
                //생성된 시드의 좌표를 현재 좌표 + 넓이, 높이 리스트 배열 값으로 대입
                temp.transform.position = new Vector2(transform.position.x + size.x, transform.position.y + lastHeight[i]);
                //생성된 시드에게 시드 생성을 요청
                temp.GetComponent<MapSeed>().CreateSeed(instance,dir);
            }
            //마지막 끝내기 시드를 생성
            else {
                //WallMaker(i,instance,dir);
            }
        }
    }

    

    //끝내기 시드를 생성
    void WallMaker(int index,MapCreator instance,int dir)
    {
        RaycastHit hit, hit2;
        //시드를 생성

        //
        Physics.Raycast(lastLand[index].transform.position, Vector3.right, out hit2, 10f , LayerMask.GetMask("Ground"));
        GameObject temp = Instantiate(instance.wall);
        //시드를 연결 시드 리스트에 등록
        childSeed.Add(temp.GetComponent<MapSeed>());
        //시드의 좌표를 지정
        temp.transform.position = new Vector2(transform.position.x + (dir * size.x), transform.position.y + lastHeight[index]);

        if (hit2.collider != null) {
            if(hit2.collider.transform.root.name.Contains("11"))
            print(hit2.collider.transform.root.name+"|"+hit2.distance);
            temp.transform.GetChild(0).localScale = new Vector3(hit2.distance, temp.transform.GetChild(0).localScale.y, temp.transform.GetChild(0).localScale.z);
            temp.GetComponent<MapSeed>().lastLand[0].transform.localPosition = new Vector3(hit2.distance - 0.5f,0,0);
        }

        //벽의 위치에서 위로 레이 캐스트를 쏩니다. >> 길이 = 현재 시드의 높이 + 에디터의 추가 높이 / 그라운드 만 체크
        Physics.Raycast(temp.GetComponent<MapSeed>().lastLand[0].transform.position, Vector3.up, out hit, size.y + instance.maringH, LayerMask.GetMask("Ground"));

        //다른 시드와 충돌 하는 경우
        if (hit.collider != null)
        {
            //충돌한 거리 만큼만 벽을 올림
            temp.GetComponent<MapSeed>().lastLand[0].transform.localScale = new Vector3(hit.distance, 1, 1.5f);
        }
        else
        {
            //시드 그룹 과 충돌 하는가?
            Physics.Raycast(temp.GetComponent<MapSeed>().lastLand[0].transform.position, Vector3.up, out hit, size.y + instance.maringH, LayerMask.GetMask("SeedGroup"));
            if (hit.collider != null)
            {
                temp.GetComponent<MapSeed>().lastLand[0].transform.localScale = new Vector3(hit.distance, 1, 1.5f);
            }
            //높이를 최고 높이로 지정
            else
                temp.GetComponent<MapSeed>().lastLand[0].transform.localScale = new Vector3(size.y + instance.maringH, 1, 1.5f);

        }
        //시드를 크리에이터에 옮김.
        temp.transform.parent = instance.gameObject.transform;
    }
    

}
