using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC의 최상위 클래스 입니다.
/// </summary>
[System.Serializable]
public class NPC
{
    /// <summary>
    /// NPC 설명
    /// </summary>
    public Explain explain;

    /// <summary>
    /// 기분
    /// </summary>
    public Emotion emotion;
    /// <summary>
    /// 감정
    /// </summary>
    public Sensitivity sensitivity;
    /// <summary>
    /// 기운
    /// </summary>
    public Energy energy;
    /// <summary>
    /// 만난 시간
    /// </summary>
    public MeetTime meetTime;
    /// <summary>
    /// 말투 
    /// </summary>
    public Speech speech;
    /// <summary>
    /// 교환 가능 물품
    /// </summary>
    public List<int> haveItemList;
    /// <summary>
    /// 대화 리스트
    /// </summary>
    public List<NPCMessage> talkList;

    /// <summary>
    /// 기분 수치를 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct Emotion
    {
        /// <summary>
        /// 기쁨
        /// </summary>
        public float delight;
        /// <summary>
        /// 분노
        /// </summary>
        public float anger;
        /// <summary>
        /// 슬픔
        /// </summary>
        public float sorrow;
        /// <summary>
        /// 즐거움
        /// </summary>
        public float joy;
        /// <summary>
        /// 사랑
        /// </summary>
        public float love;
        /// <summary>
        /// 미움
        /// </summary>
        public float hate;

        public int CheckEmotion()
        {
            int res = 0;
            //긍정, 부정
            float positive, negative;
            positive = (this.delight + this.joy + this.love) / 3;
            negative = (this.anger + this.sorrow + this.hate) / 3;

            //긍정
            if (positive > negative)
                res = 1;
            //부정
            else
                res = -1;

            return res;
        }

    }

    /// <summary>
    /// 감정 수치를 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct Sensitivity
    {
        /// <summary>
        /// 현재 감정 수치
        /// </summary>
        public int currentSensitivity;
        /// <summary>
        /// 최대 감정 수치
        /// </summary>
        public int totalSensitivity;
        /// <summary>
        /// 최소 감정 수치 범위
        /// </summary>
        public int minSensitivity;
        /// <summary>
        /// 최대 감정 수치 범위 
        /// </summary>
        public int maxSensitivity;

        /// <summary>
        /// 감정 수치를 불러옵니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void LoadData(int id, string name)
        {
            currentSensitivity = PlayerPrefs.GetInt("Npc" + id + name + "CurrentSensitivity", 0);
            totalSensitivity = PlayerPrefs.GetInt("Npc" + id + name + "TotalSensitivity", Random.Range(minSensitivity, maxSensitivity));
        }

        /// <summary>
        /// 감정 수치를 저장합니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void SaveData(int id, string name)
        {
            PlayerPrefs.SetInt("Npc" + id + name + "CurrentSensitivity", currentSensitivity);
            PlayerPrefs.SetInt("Npc" + id + name + "TotalSensitivity", totalSensitivity);
        }
    }

    /// <summary>
    /// 에너지를 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct Energy
    {
        /// <summary>
        /// 현재 에너지 수치
        /// </summary>
        public int currentEnergy;
        /// <summary>
        /// 최대 에너지 수치
        /// </summary>
        public int totalEnergy;
        /// <summary>
        /// 최소 에너지 수치 범위
        /// </summary>
        public int minEnergy;
        /// <summary>
        /// 최대 에너지 수치 범위
        /// </summary>
        public int maxEnergy;

        /// <summary>
        /// 에너지 수치를 저장합니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void LoadData(int id, string name)
        {
            currentEnergy = PlayerPrefs.GetInt("Npc" + id + name + "CurrentEnergy", 0);
            totalEnergy = PlayerPrefs.GetInt("Npc" + id + name + "TotalEnergy", Random.Range(minEnergy, maxEnergy));
        }

        /// <summary>
        /// 에너지 수치를 불러옵니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void SaveData(int id, string name)
        {
            PlayerPrefs.SetInt("Npc" + id + name + "CurrentEnergy", currentEnergy);
            PlayerPrefs.SetInt("Npc" + id + name + "TotalEnergy", totalEnergy);
        }
    }

    /// <summary>
    /// 최근 만난 날을 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct MeetTime
    {
        /// <summary>
        /// 최근 만난 날
        /// </summary>
        public string lastMeet;
        /// <summary>
        /// 특수 한 날
        /// </summary>
        public string specialDay;
        /// <summary>
        /// 등장 날 빈도
        /// </summary>
        public int frequencyMeet;

        /// <summary>
        /// 최근 만난 날짜를 불러옵니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void LoadData(int id, string name)
        {
            lastMeet = PlayerPrefs.GetString("Npc" + id + name + "LastMeet", "????-??-??");
        }

        /// <summary>
        /// 최근 만난 날짜를 저장합니다.
        /// </summary>
        /// <param name="id">NPC 아이디</param>
        /// <param name="name">NPC 이름</param>
        public void SaveData(int id, string name)
        {
            PlayerPrefs.GetString("Npc" + id + name + "LastMeet", lastMeet);
        }
    }

    /// <summary>
    /// 말투를 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct Speech
    {
        /// <summary>
        /// 접두사
        /// </summary>
        public string headTalk;

        /// <summary>
        /// 접미사
        /// </summary>
        public string tailTalk;

    }

    /// <summary>
    /// 관심을 관리하는 구조체
    /// </summary>
    [System.Serializable]
    public struct Interest
    {
        public enum category {
            a,
            b,
            c
        }
    }

}
