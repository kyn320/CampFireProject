using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMessageManager : MonoBehaviour
{

    public static NPCMessageManager instance;

    public GameObject[] msgBoxList;
    public List<NPCMessage> msgList;

    void Awake()
    {
        instance = this;
    }

    public void UpdateMsg()
    {
        for (int i = 0; i < msgBoxList.Length; i++)
        {
            if (msgList.Count - 1 >= i)
            {
                MsgSet(i);
            }
            else {
                msgBoxList[i].SetActive(false);
            }
        }
    }

    public void MsgSet(int num)
    {
        Color colorData;

        //이름 설정
        msgBoxList[num].transform.GetChild(0).GetComponent<Text>().text = msgList[num].Name;
        ColorUtility.TryParseHtmlString(msgList[num].NameColor, out colorData);
        msgBoxList[num].transform.GetChild(0).GetComponent<Text>().color = colorData;

        //내용 설정
        msgBoxList[num].transform.GetChild(1).GetComponent<Text>().text = msgList[num].Context;
        ColorUtility.TryParseHtmlString(msgList[num].ContextColor, out colorData);
        msgBoxList[num].transform.GetChild(1).GetComponent<Text>().color = colorData;
        msgBoxList[num].transform.GetChild(1).GetComponent<Text>().fontSize = msgList[num].ContextFontSize;

        msgBoxList[num].SetActive(true);
    }

    public void AddMsg(NPCMessage data)
    {
        if (msgList.Count > 3)
            msgList.RemoveAt(0);

        msgList.Add(data);

        UpdateMsg();
    }

    public void RemoveMsg()
    {
        if (msgList.Count > 0)
        {
            msgList.RemoveAt(0);
            UpdateMsg();
        }
    }

}

[System.Serializable]
public class NPCMessage
{
    public string Name;
    [TextArea]
    public string Context;
    public string NameColor = "#ffffff", ContextColor = "#ffffff";
    public int ContextFontSize = 20;

    public NPCMessage Clone()
    {
        NPCMessage temp = new NPCMessage();
        temp.Name = this.Name;
        temp.Context = this.Context;
        temp.NameColor = this.NameColor;
        temp.ContextColor = this.ContextColor;
        temp.ContextFontSize = this.ContextFontSize;

        return temp;
    }

}