using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBox : MonoBehaviour
{

    public List<int> dropItemList;
    public int boxValue;

    public void LoadData()
    {
        boxValue = PlayerPrefs.GetInt("MemoryBoxValue", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("MemoryBoxValue", boxValue);
    }

}
