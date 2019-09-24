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

    public delegate void EventHandler();
    public static event EventHandler EndGameEvent;
    
    public static event EventHandler StartGameEvnet;


    //------------------------------------------------------

    public GameObject UIImg;

    public List<GameObject> UIBtnControl;

    public UIBoolSet UISet;
    
    public List<GameObject> UIList;
    public List<GameObject> Stage;
    public int ativeStage = -1;

    public Text rewardMoney;

    public bool dragging = false;
    public GameObject dragObj;

    private CharacterState nowClickCState;



    private void InitScene()
    {
        UIBtnControl.Add(UIList[0]);
        foreach (GameObject item in UIBtnControl)
        {
            item.SetActive(false);
        }

        foreach (var item in UIList)
        {
            item.SetActive(false);
        }

        foreach (var item in Stage)
        {
            item.SetActive(false);
        }


        UISet.startAndOption = true;
        UISet.stageSelect = false;
        UIList[0].SetActive(true);
    }

    
	private void Start () {
        
        instance = this.gameObject.GetComponent<UIManager>();


        InitScene();



        

        
        dragObj.SetActive(false);
    }
	
	
	void Update () {

	}


    public void ButtonClike(string obj)
    {
        Debug.Log("in");
        StartCoroutine(DelayFunc(obj));
        
    }


    public void StageClick(int name)
    {
        //GameManager.instance.obPool.GetComponent<CreateObject>().SetUpMonster(GameManager.instance.characterSlot);
        GameManager.instance.initAll();
        StartGameEvnet();


        switch (name)
        {
            case 0:
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
        EndGameEvent();
        

    }


    Sprite nowSprite;
    int startclick;
    public void StartDragCharacterBtn(int i)
    {
        dragging = true;
        dragObj.SetActive(true);
        Debug.Log("??????????");
        
        nowSprite = this.GetComponent<UIScrollRectSnap>().characterBtn[i].gameObject.GetComponent<Image>().sprite;
        dragObj.GetComponent<Image>().sprite = nowSprite;
        startclick = i;

    }

    public void EndDragCharacterBtn()
    {
        dragging = false;
        dragObj.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            if (222 + (i*120) <= dragObj.transform.position.x && dragObj.transform.position.x <= 322 + (i * 120) &&
                421 <= dragObj.transform.position.y && dragObj.transform.position.y <= 521)
            {
                Debug.Log("Get" + i);
                //GameManager.instance.characterSlot[i] = nowClickCState;
                GameManager.instance.slot[i].GetComponent<Image>().sprite = nowSprite;
                GameManager.instance.obPool.GetComponent<CreateObject>().monster[i].GetComponent<CharacterState>().UpDateState(Database.instance.myMonsterList[startclick]);


            }

        }

    }

    public void DraggingCharacterBtn()
    {

        Vector3 position = Input.mousePosition;
        dragObj.transform.position = position;

    }

    IEnumerator DelayFunc(string obj)
    {
        Debug.Log("버튼 딜레이 코루틴");
        yield return new WaitForSeconds(0.5f);
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
            case "CharacterForming":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[5].SetActive(true);
                UIBtnControl.Add(UIList[5]);
                break;
            case "PowerUp":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[6].SetActive(true);
                UIBtnControl.Add(UIList[6]);
                UIImg.GetComponent<UIImage>().ImageGet();

                break;
            case "BackSapce":
                UIBtnControl[UIBtnControl.Count - 1].SetActive(false);
                UIBtnControl.RemoveAt(UIBtnControl.Count - 1);
                UIBtnControl[UIBtnControl.Count - 1].SetActive(true);
                break;
            default:
                break;
        }
    }

}
