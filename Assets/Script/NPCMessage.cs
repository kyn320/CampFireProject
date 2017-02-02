using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC 메세지 관리하는 클래스
/// </summary>
[System.Serializable]
public class NPCMessage
{
    /// <summary>
    /// 대화 내용
    /// </summary>
    [TextArea]
    public string Context;
    public int ID;
    /// <summary>
    /// 주제 설정
    /// </summary>
    public HeadComment headComment;
    /// <summary>
    /// 답변 설정
    /// </summary>
    public AnswerComment answerComment;
    /// <summary>
    /// 이름 색상
    /// </summary>
    public string NameColor = "#ffffff";
    /// <summary>
    /// 대화 색상
    /// </summary>
    public string ContextColor = "#ffffff";
    /// <summary>
    /// 대화 사이즈
    /// </summary>
    public int ContextFontSize = 20;

    [System.Serializable]
    public class HeadComment {
        public enum category {
            Question,
            Share
        }
        public int interestInfo = (int)NPC.Interest.category.a;
    }

        [System.Serializable]
    public class AnswerComment {
        public enum category {
            Reverse,
            Reaction
        }
        public string[] conjunctionList = new string[5] { "그렇지만", "그렇지마는", "다만", "하지만", "그런데" };
    }

}