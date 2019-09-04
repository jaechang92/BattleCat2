using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Database : MonoBehaviour {

    static public Database instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        MyMonsterDataLoadFunc();

    }


    public List<Monster> myMonsterList = new List<Monster>();

    public void MyMonsterDataLoadFunc()
    {
        //StartCoroutine(Co_MyLoad());
    }



}
