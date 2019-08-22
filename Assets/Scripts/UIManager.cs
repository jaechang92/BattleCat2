using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UIBoolSet
{
    public bool mainMenu;
    public bool stageSelect;
}

public class UIManager : MonoBehaviour {


    public UIBoolSet UISet;
    public List<GameObject> UIList;
	
	void Start () {
        UISet.mainMenu = true;
        UISet.stageSelect = false;
	}
	
	
	void Update () {
        
	}


    public void ButtonClike(string obj)
    {
        Debug.Log("in");
        switch (obj)
        {
            case "Start":
                UIList[0].SetActive(false);
                UIList[1].SetActive(true);
                break;
            case "Option":
                break;
            

            default:
                break;
        }
    }
}
