using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 음식 클래스
/// </summary>
public class Food
{
    /// <summary>
    /// 설명
    /// </summary>
    public Explain explain;

    /// <summary>
    /// 접두사 카테고리
    /// </summary>
    public enum HeadCategory
    {
        boiled,//삶은
        roast,//구운
        fried,//튀긴
        poached,//데친
        heated//끓인
    }

    /// <summary>
    /// 접미사 카테고리
    /// </summary>
    public enum BackCategory {

    }

    /// <summary>
    /// 독립 카테고리
    /// </summary>
    public enum IndependentCategory {
        drink // 마실 수 있는
    }

}
