using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵의 시드입니다.
/// </summary>
public class MapSeed : MonoBehaviour
{

    /// <summary>
    /// 시드의 아이디
    /// </summary>
    public int ID;
    /// <summary>
    /// 넓이
    /// </summary>
    public Vector2 width;
    /// <summary>
    /// 처음 높이 값
    /// </summary>
    public float firstHeight;
    /// <summary>
    /// 마지막 높이 값
    /// </summary>
    public float lastHeight;
    /// <summary>
    /// 시드가 가지고 있는 방향 리스트입니다.
    /// </summary>
    public List<direction> directionList;
    /// <summary>
    /// 시드의 방향을 지정하는 상수 값
    /// </summary>
    [SerializeField]
    public enum direction
    {
        up, down,
        left, right
    }

    public GameObject LoadPrefab()
    {
        return Resources.Load<GameObject>("3D/Seed/" + gameObject.name);
    }

    public void SetWidth()
    {
        Vector2 temp = Vector2.zero;
        for (int i = 0; i < transform.childCount; i++)
        {
            float x = transform.GetChild(i).localScale.x * transform.GetChild(i).GetChild(0).GetComponent<MeshFilter>().mesh.bounds.size.x;
            temp.x += x;
            if (i + 1 < transform.childCount)
            {
                temp.x += transform.GetChild(i + 1).transform.position.x - x;
            }
            if (temp.y < transform.GetChild(i).position.y)
                temp.y = transform.GetChild(i).position.y;
        }
        width = temp;
    }

    public void SetHeight()
    {
        firstHeight = transform.GetChild(0).position.y;
        lastHeight = transform.GetChild(transform.childCount - 1).position.y;
    }

}
