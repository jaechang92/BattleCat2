using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UIBoolSet
{
    public bool startAndOption;
    public bool stageSelect;
    public bool main;
    public bool battleMap;
    public bool battleStage;
}

public class UIManager : MonoBehaviour {

    static public UIManager instance;
    
    public UIBoolSet UISet;
    
    public List<GameObject> UIList;
    public List<GameObject> Stage;
    public int ativeStage = -1;

	void Start () {
        UISet.startAndOption = true;
        UISet.stageSelect = false;

        UIList[0].SetActive(true);
        instance = this.gameObject.GetComponent<UIManager>();
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

                UIList[2].SetActive(false);
                UIList[3].SetActive(true);

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


    public void StageClick(string name)
    {
        switch (name)
        {
            case "Korea":
                GetStage(0);
                Debug.Log("한국 스테이지");
                break;

            default:
                break;
        }
    }

    private void GetStage(int num)
    {
        Stage[num].SetActive(true);
        ativeStage = num;
    }

    public void EndStage()
    {
        Stage[ativeStage].SetActive(false);
        ativeStage = -1;
        Debug.Log("끝");
    }


}
