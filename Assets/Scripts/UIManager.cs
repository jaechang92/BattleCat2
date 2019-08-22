using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UIBoolSet
{
    public bool startAndOption;
    public bool stageSelect;
    public bool main;
    public bool battleStage;
}

public class UIManager : MonoBehaviour {


    public UIBoolSet UISet;
    
    public List<GameObject> UIList;
	
	void Start () {
        UISet.startAndOption = true;
        UISet.stageSelect = false;

        UIList[0].SetActive(true);
	}
	
	
	void Update () {
        
	}


    public void ButtonClike(string obj)
    {
        Debug.Log("in");
        switch (obj)
        {
            case "Start":
                UISet.startAndOption = false;
                UISet.stageSelect = true;

                UIList[0].SetActive(false);
                UIList[1].SetActive(true);
                break;
            case "Option":
                break;
            case "World":
                UISet.stageSelect = false;
                UISet.main = true;

                UIList[1].SetActive(false);
                UIList[2].SetActive(true);
                break;
            case "Future":
                break;
            case "CatSchool":
                break;


            case "BattleMenu":
                break;
            case "PowerUp":
                break;
            case "CharacterForming":
                break;
            case "BackSapce":
                break;
            default:
                break;
        }
    }
}
