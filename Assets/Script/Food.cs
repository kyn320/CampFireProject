using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public Explain explain;
    public enum HeadCategory
    {
        boiled,//삶은
        roast,//구운
        fried,//튀긴
        poached,//데친
        heated//끓인
    }
    public enum BackCategory {

    }

    public enum IndependentCategory {
        drink // 마실 수 있는
    }

}
