using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainManager : MonoBehaviour
{

    public static UIMainManager instance;


    public Text woodText, fireText, stoneText;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void OnChangeWoodValue(int value)
    {
        woodText.text = value + "개";
    }

    public void OnChangeFireValue(int value)
    {
        fireText.text = value + "개";
    }

    public void OnChangeStoneValue(int value)
    {
        stoneText.text = value + "개";
    }

}
