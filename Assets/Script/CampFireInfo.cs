using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CampFireInfo
{

    //========= 기본 정보 ===========
    public LevelData levelData;
    public Durability durability;
    public StatusPoint statusPoint;
    public WearData wearData;
    public GetItemRange getItemRange;

    //========= 스테이터스 ============
    public JoinMember joinMember;
    public GetItemMaxPercent getItemMaxPercent;
    public CookingMaxSlot cookaingMaxSlot;
    public CookTimeMinus cookTimeMinus;
    public CookingLevel cookingLevel;
    public DurabilityPlus durabilityPlus;
    public DurabilitySpeed durabilitySpeed;
    public EnergySpeed energySpeed;
    public MaxBatchObjects maxBatchObjects;
    
    [System.Serializable]
    public struct LevelData
    {
        public int Level;
        public int currentExp;
        public List<int> maxExp;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("CampLevel", 1);
            currentExp = PlayerPrefs.GetInt("CampExp", 0);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("CampLevel", Level);
            PlayerPrefs.SetInt("CampExp", currentExp);
        }
    }

    [System.Serializable]
    public struct Durability
    {
        public int Level;
        public int currentDurability;
        public List<int> maxDurability;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("Durability", 0);
            currentDurability = PlayerPrefs.GetInt("CurrentDurability", 0);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("Durability", Level);
            PlayerPrefs.SetInt("CurrentDurability", currentDurability);
        }

    }

    [System.Serializable]
    public struct StatusPoint
    {
        public int Level;
        public int currentPoint;
        public List<int> addPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("StatusPoint", 0);
            currentPoint = PlayerPrefs.GetInt("CurrentPoint", 0);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("StatusPoint", Level);
            PlayerPrefs.SetInt("CurrentPoint", currentPoint);
        }

    }

    [System.Serializable]
    public struct WearData
    {
        public int wearCampFire;
        public string wearFire, wearWood;

        public void LoadData()
        {
            wearCampFire = PlayerPrefs.GetInt("WearCampFire", 0);
            wearFire = PlayerPrefs.GetString("WearFire", "");
            wearWood = PlayerPrefs.GetString("WearWood", "");
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("WearCampFire", wearCampFire);
            PlayerPrefs.SetString("WearFire", wearFire);
            PlayerPrefs.SetString("WearWood", wearWood);
        }

    }

    [System.Serializable]
    public struct GetItemRange
    {
        public int minRange, maxRange;
        public void LoadData()
        {
            minRange = PlayerPrefs.GetInt("GetItemMinRange", 1);
            maxRange = PlayerPrefs.GetInt("GetItemMaxRange", 2);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("GetItemMinRange", minRange);
            PlayerPrefs.SetInt("GetItemMaxRange", maxRange);
        }

    }

    [System.Serializable]
    public struct JoinMember
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("JoinMember", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("JoinMember", Level);
        }

    }

    [System.Serializable]
    public struct GetItemMaxPercent
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("GetItemMaxPercent", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("GetItemMaxPercent", Level);
        }
    }

    [System.Serializable]
    public struct CookingMaxSlot
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("CookingMaxSlot", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("CookingMaxSlot", Level);
        }
    }

    [System.Serializable]
    public struct CookTimeMinus
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("CookTimeMinus", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("CookTimeMinus", Level);
        }
    }

    [System.Serializable]
    public struct CookingLevel
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("CookingLevel", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("CookingLevel", Level);
        }
    }

    [System.Serializable]
    public struct DurabilityPlus
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("DurabilityPlus", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("DurabilityPlus", Level);
        }
    }

    [System.Serializable]
    public struct DurabilitySpeed
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("DurabilitySpeed", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("DurabilitySpeed", Level);
        }
    }

    [System.Serializable]
    public struct EnergySpeed
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("EnergySpeed", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("EnergySpeed", Level);
        }
    }

    [System.Serializable]
    public struct MaxBatchObjects
    {
        public int Level;
        public List<int> reqPoint;

        public void LoadData()
        {
            Level = PlayerPrefs.GetInt("MaxBatchObjects", 1);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("MaxBatchObjects", Level);
        }
    }


    public void AllLoadData()
    {
        levelData.LoadData();
        durability.LoadData();
        statusPoint.LoadData();
        wearData.LoadData();
        getItemRange.LoadData();

        joinMember.LoadData();
        getItemMaxPercent.LoadData();
        cookaingMaxSlot.LoadData();
        cookTimeMinus.LoadData();
        cookingLevel.LoadData();
        durabilityPlus.LoadData();
        durabilitySpeed.LoadData();
        energySpeed.LoadData();
        maxBatchObjects.LoadData();
    }

    public void AllSaveData()
    {
        levelData.SaveData();
        durability.SaveData();
        statusPoint.SaveData();
        wearData.SaveData();
        getItemRange.SaveData();

        joinMember.SaveData();
        getItemMaxPercent.SaveData();
        cookaingMaxSlot.SaveData();
        cookTimeMinus.SaveData();
        cookingLevel.SaveData();
        durabilityPlus.SaveData();
        durabilitySpeed.SaveData();
        energySpeed.SaveData();
        maxBatchObjects.SaveData();
    }



}
