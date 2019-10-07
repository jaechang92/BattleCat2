using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpGrade : MonoBehaviour {

    static public CheckUpGrade instance;

    public OutLineControll olc;
    public UserInfo Info;
    public int myXp;
    public int needXp;
    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        GetMyXp();
    }
	
	void Update () {

        if (myXp >= needXp)
        {
            olc.selectThis = true;
        }
        else
        {
            olc.selectThis = false;
        }

	}

    public void GetMyXp()
    {
        myXp = Info.userXp;
    }

    public void SetNeedXp(int num)
    {
        needXp = num;
    }

}
