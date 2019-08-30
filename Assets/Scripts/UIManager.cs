using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<GameObject> UIBtnControl;

    public UIBoolSet UISet;
    
    public List<GameObject> UIList;
    public List<GameObject> Stage;
    public int ativeStage = -1;

    public Text rewardMoney;
   

	void Start () {
        
        instance = this.gameObject.GetComponent<UIManager>();

        UIBtnControl.Add(UIList[0]);

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
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[1].SetActive(true);
                UIBtnControl.Add(UIList[1]);
                

                break;
            case "Option":

                break;
            case "World":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[2].SetActive(true);
                UIBtnControl.Add(UIList[2]);
                break;
            case "Future":
                break;
            case "CatSchool":
                break;


            case "BattleMenu":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[3].SetActive(true);
                UIBtnControl.Add(UIList[3]);

                break;
            case "PowerUp":
                break;
            case "CharacterForming":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[5].SetActive(true);
                UIBtnControl.Add(UIList[5]);
                break;
            case "BackSapce":
                UIBtnControl[UIBtnControl.Count - 1].SetActive(false);
                UIBtnControl.RemoveAt(UIBtnControl.Count-1);
                UIBtnControl[UIBtnControl.Count - 1].SetActive(true);
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

    public void GetMoney(int money)
    {
        rewardMoney.text = money.ToString();
    }


    public void EndStage()
    {
        Stage[ativeStage].SetActive(false);
        ativeStage = -1;
        Debug.Log("끝");
    }

    public void OKButton()
    {
        EndStage();
        UIList[4].SetActive(false);
        UIBtnControl[UIBtnControl.Count - 1].SetActive(false);
        UIBtnControl.RemoveAt(UIBtnControl.Count - 1);
        UIBtnControl[UIBtnControl.Count - 1].SetActive(true);
    }


}
