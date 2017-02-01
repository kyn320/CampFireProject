using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPC
{
    public Explain explain;

    public Emotion emotion;
    public Sensitivity sensitivity;
    public Energy energy;
    public MeetTime meetTime;
    public Speech speech;

    public List<int> haveItemList;
    public List<NPCMessage> talkList;

    [System.Serializable]
    public struct Emotion {
        //기쁨
        public float delight;
        //분노
        public float anger;
        //슬픔
        public float sorrow;
        //즐거움
        public float joy;
        //사랑
        public float love;
        //미움
        public float hate;
        //욕망
        public float will;

    }


    [System.Serializable]
    public struct Sensitivity
    {
        public int currentSensitivity, totalSensitivity;
        public int minSensitivity, maxSensitivity;

        public void LoadData(int id, string name)
        {
            currentSensitivity = PlayerPrefs.GetInt("Npc" + id + name + "CurrentSensitivity", 0);
            totalSensitivity = PlayerPrefs.GetInt("Npc" + id + name + "TotalSensitivity", Random.Range(minSensitivity, maxSensitivity));
        }

        public void SaveData(int id, string name)
        {
            PlayerPrefs.SetInt("Npc" + id + name + "CurrentSensitivity", currentSensitivity);
            PlayerPrefs.SetInt("Npc" + id + name + "TotalSensitivity", totalSensitivity);
        }
    }

    [System.Serializable]
    public struct Energy
    {
        public int currentEnergy, totalEnergy;
        public int minEnergy, maxEnergy;

        public void LoadData(int id, string name)
        {
            currentEnergy = PlayerPrefs.GetInt("Npc" + id + name + "CurrentEnergy", 0);
            totalEnergy = PlayerPrefs.GetInt("Npc" + id + name + "TotalEnergy", Random.Range(minEnergy, maxEnergy));
        }

        public void SaveData(int id, string name)
        {
            PlayerPrefs.SetInt("Npc" + id + name + "CurrentEnergy", currentEnergy);
            PlayerPrefs.SetInt("Npc" + id + name + "TotalEnergy", totalEnergy);
        }
    }

    [System.Serializable]
    public struct MeetTime {
        public string lastMeet;
        public string specialDay;
        public int frequencyMeet;

        public void LoadData(int id, string name)
        {
            lastMeet = PlayerPrefs.GetString("Npc" + id + name + "LastMeet","????-??-??");
        }

        public void SaveData(int id, string name)
        {
            PlayerPrefs.GetString("Npc" + id + name + "LastMeet", lastMeet);
        }
    }

    [System.Serializable]
    public struct Speech{
        public string talk;
    }

}
