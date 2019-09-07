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

    public Monster MyMonsterFindFunc(int monsterID)
    {
        foreach (Monster item in myMonsterList)
        {
            if (item.monsterID == monsterID)
            {
                return item;
            }
        }
        Debug.LogError("찾는 몬스터 ID가 존재하지 않습니다.");
        return null;
    }

}
