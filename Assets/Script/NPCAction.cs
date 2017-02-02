using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// NPC의 행동이 실행되는 객체
/// </summary>
public class NPCAction : MonoBehaviour {

    public NPC npcInfo;
    public GameObject msgBox;
    public NPCMessage msgData;

    void Start() {
        StartCoroutine("MessageUpdate");
        StartCoroutine("EnergyAdd");
    }


    IEnumerator EnergyAdd() {
        while (npcInfo.energy.currentEnergy < npcInfo.energy.totalEnergy) {
            yield return new WaitForSeconds(5f - ( 0.1f *  CampFire.Instance.info.energySpeed.Level));
            npcInfo.energy.currentEnergy += 1;
        }
    }

    IEnumerator MessageUpdate() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 15f));
            msgData = npcInfo.talkList[Random.Range(0, npcInfo.talkList.Count)];
            msgData.Context += npcInfo.speech.tailTalk;
            MsgSet();
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            msgBox.SetActive(false);
        }
    }

    public void MsgSet()
    {
        Color colorData;

        //이름 설정
        msgBox.transform.GetChild(0).GetComponent<Text>().text = npcInfo.explain.Name;
        ColorUtility.TryParseHtmlString(msgData.NameColor, out colorData);
        msgBox.transform.GetChild(0).GetComponent<Text>().color = colorData;

        //내용 설정
        msgBox.transform.GetChild(1).GetComponent<Text>().text = msgData.Context;
        ColorUtility.TryParseHtmlString(msgData.ContextColor, out colorData);
        msgBox.transform.GetChild(1).GetComponent<Text>().color = colorData;
        msgBox.transform.GetChild(1).GetComponent<Text>().fontSize = msgData.ContextFontSize;

        msgBox.SetActive(true);
    }

}
