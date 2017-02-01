using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzle : MonoBehaviour
{

    public static MemoryPuzzle instance;

    public int[] havePuzzleList;
    public int parts;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        LoadData();
    }


    public void AddPuzzleParts(int value)
    {
        int data = PlayerPrefs.GetInt("MemoryPuzzle", 0);
        PlayerPrefs.SetInt("MemoryPuzzle", data + value);
    }

    public void LoadData()
    {
        parts = PlayerPrefs.GetInt("MemoryPuzzle", 0);
        string data = PlayerPrefs.GetString("MemoryPuzzleList", "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
        if (data != "")
        {
            string[] list = data.Split(',');
            for (int i = 0; i < list.Length; i++)
            {
                int.TryParse(list[i], out havePuzzleList[i]);
            }
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("MemoryPuzzle", parts);
        string data = havePuzzleList[0].ToString();
        for (int i = 1; i < havePuzzleList.Length; i++)
        {
            data += "," + havePuzzleList[i].ToString();
        }
        PlayerPrefs.SetString("MemoryPuzzleList", data);
    }

}
