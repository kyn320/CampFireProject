using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 설명 클래스
/// </summary>
[System.Serializable]
public class Explain
{
    public int Id = 0;
    public string Name = "", Context = "", Icon = "", Model = "";

    /// <summary>
    /// 나무 불 돌 순서
    /// </summary>
    public List<int> reqMaterialValue;

    /// <summary>
    /// 아이콘을 로드합니다,
    /// </summary>
    /// <returns>Sprite를 리턴합니다.</returns>
    public Sprite LoadIcon()
    {
        return Resources.Load<Sprite>("Icon/" + Icon);
    }

    /// <summary>
    /// 모델링을 로드합니다.
    /// </summary>
    /// <returns>GameObject를 리턴합니다.</returns>
    public GameObject Loadmodel()
    {
        return Resources.Load<GameObject>("Model/" + Model);
    }


}
