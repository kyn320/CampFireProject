using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour {

    private static CampFire _instance;
    public static CampFire Instance {
        get {
            return _instance;
        }
        set {
            _instance = value;
        }
    }

    public CampFireInfo info;

    void Awake()
    {
        Instance = this;
        info.AllLoadData();
        DontDestroyOnLoad(this.gameObject);
    }



}
