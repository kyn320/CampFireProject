using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임을 관리하는 최상위 매니저
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 싱글톤 
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// 진행중인 버프리스트
    /// </summary>
    public List<Buff> buffList;

    /// <summary>
    /// 소유중인 아이템
    /// </summary>
    public int wood, fire, stone;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayCasting(ray);
        }
    }

    void RayCasting(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.transform.CompareTag("TouchArea"))
            {
                GetItem();
            }
        }
    }


    void GetItem()
    {

        float percent = 0.4f * CampFire.Instance.info.getItemMaxPercent.Level;
        int min, max;
        min = CampFire.Instance.info.getItemRange.minRange;
        max = CampFire.Instance.info.getItemRange.maxRange;
        float value = Random.Range(0, 101);
        if (value < 10f + percent)
        {
            switch ((int)Random.Range(0, 3))
            {
                case 0: ChangeWood(Random.Range(min + 1, max + 1)); break;
                case 1: ChangeFire(Random.Range(min + 1, max + 1)); break;
                case 2: ChangeStone(Random.Range(min + 1, max + 1)); break;
                default: break;
            }
        }
        else {
            switch ((int)Random.Range(0, 3))
            {
                case 0: ChangeWood(min); break;
                case 1: ChangeFire(min); break;
                case 2: ChangeStone(min); break;
                default: break;
            }
        }
    }

    void ChangeWood(int value)
    {
        wood += value;
        UIMainManager.instance.OnChangeWoodValue(wood);
    }

    void ChangeFire(int value)
    {
        fire += value;
        UIMainManager.instance.OnChangeFireValue(fire);
    }

    void ChangeStone(int value)
    {
        stone += value;
        UIMainManager.instance.OnChangeStoneValue(stone);
    }

    public void LoadData()
    {
        wood = PlayerPrefs.GetInt("PlayerData_Wood", 0);
        fire = PlayerPrefs.GetInt("PlayerData_Fire", 0);
        stone = PlayerPrefs.GetInt("PlayerData_Stone", 0);
        UIMainManager.instance.OnChangeWoodValue(wood);
        UIMainManager.instance.OnChangeFireValue(fire);
        UIMainManager.instance.OnChangeStoneValue(stone);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerData_Fire", fire);
        PlayerPrefs.SetInt("PlayerData_Wood", wood);
        PlayerPrefs.SetInt("PlayerData_Stone", stone);
    }



}
