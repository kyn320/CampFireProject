using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCommunicationManager : MonoBehaviour
{

    public List<NPCMessage> QuestionMsgList;
    public List<NPCMessage> ShareMsgList;
    public List<NPCMessage> ReverseMsgList;
    public List<NPCMessage> PositiveMsgList;
    public List<NPCMessage> NegativeMsgList;


    public NPCMessage FindQuestionMsgListWithID(int id)
    {
        for (int i = 0; i < QuestionMsgList.Count; i++) {
            if (QuestionMsgList[i].ID == id)
                return QuestionMsgList[i];
        }
        return null;
    }

    public NPCMessage FindShareMsgListWithID(int id)
    {
        for (int i = 0; i < ShareMsgList.Count; i++)
        {
            if (ShareMsgList[i].ID == id)
                return ShareMsgList[i];
        }
        return null;
    }

    public NPCMessage FindReverseMsgListWithID(int id)
    {
        for (int i = 0; i < ReverseMsgList.Count; i++)
        {
            if (ReverseMsgList[i].ID == id)
                return ReverseMsgList[i];
        }
        return null;
    }

    public NPCMessage FindPositiveMsgListWithID(int id)
    {
        for (int i = 0; i < PositiveMsgList.Count; i++)
        {
            if (PositiveMsgList[i].ID == id)
                return PositiveMsgList[i];
        }
        return null;
    }

    public NPCMessage FindNegativeMsgListWithID(int id)
    {
        for (int i = 0; i < NegativeMsgList.Count; i++)
        {
            if (NegativeMsgList[i].ID == id)
                return NegativeMsgList[i];
        }
        return null;
    }


}
