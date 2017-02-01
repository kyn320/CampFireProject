using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            msgData = npcInfo.talkList[Random.Range(0, npcInfo.talkList.Count)].Clone();
            msgData.Name = npcInfo.explain.Name;
            msgData.Context += npcInfo.speech.talk;
            NPCMessageManager.instance.AddMsg(msgData);
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            NPCMessageManager.instance.RemoveMsg();
        }
    }


}
