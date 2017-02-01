using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Explain
{
    public int Id = 0;
    public string Name = "", Context = "", Icon = "", Model = "";

    /// <summary>
    /// 나무 불 돌 순서
    /// </summary>
    public List<int> reqMaterialValue;

    public Sprite LoadIcon()
    {
        return Resources.Load<Sprite>("Icon/" + Icon);
    }

    public GameObject Loadmodel()
    {
        return Resources.Load<GameObject>("Model/" + Model);
    }


}
