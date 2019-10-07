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
    private UIImage pUi; // powerup UIImag

    public List<GameObject> UIBtnControl;

    public UIBoolSet UISet;
    
    public List<GameObject> UIList;
    public List<GameObject> Stage;
    public int ativeStage = -1;

    public Text rewardMoney;
    public Text stageName;
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



        pUi = UIImg.GetComponent<UIImage>();



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
        

        UIList[2].SetActive(false);
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
        UIList[2].SetActive(true);
        SoundControll.instance.BackgoundSoundChange(1);

    }


    Sprite nowSprite;
    int startclick;
    public void StartDragCharacterBtn(int i)
    {
        dragging = true;
        dragObj.SetActive(true);
        //Debug.Log("??????????");
        
        nowSprite = this.GetComponent<UIScrollRectSnap>().characterBtn[i].gameObject.GetComponent<Image>().sprite;
        dragObj.GetComponent<Image>().sprite = nowSprite;
        startclick = i;

    }

    public void EndDragCharacterBtn()
    {
        dragging = false;
        dragObj.SetActive(false);
        Debug.Log(dragObj.transform.position);
        for (int i = 0; i < 5; i++)
        {
            if (GameManager.instance.slot[i].GetComponent<Transform>().position.x - 50 <= dragObj.transform.position.x &&
                GameManager.instance.slot[i].GetComponent<Transform>().position.x + 50 >= dragObj.transform.position.x &&
                GameManager.instance.slot[i].GetComponent<Transform>().position.y - 50 <= dragObj.transform.position.y &&
                GameManager.instance.slot[i].GetComponent<Transform>().position.y + 50 >= dragObj.transform.position.y)
            {
                Debug.Log("Get" + i);
                GameManager.instance.slot[i].GetComponent<Image>().sprite = nowSprite;
                GameManager.instance.obPool.GetComponent<CreateObject>().monster[i].GetComponent<CharacterState>().UpDateState(Database.instance.myMonsterList[startclick]);
                GameManager.instance.slot[i].GetComponent<Slot>().num = startclick;
            }

            //if (290 + (i*140) <= dragObj.transform.position.x && dragObj.transform.position.x <= 390 + (i * 140) &&
            //    510 <= dragObj.transform.position.y && dragObj.transform.position.y <= 610)
            //{
                
            //    //GameManager.instance.characterSlot[i] = nowClickCState;
               


            //}

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
        SoundControll.instance.ClickSoundPlay(0);
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
                SoundControll.instance.BackgoundSoundChange(1);
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[2].SetActive(true);
                UIBtnControl.Add(UIList[2]);
                stageName.text = "고양이 기지";
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
                UIList[2].SetActive(true);
                UIList[3].SetActive(true);


                UIBtnControl.Add(UIList[3]);
                stageName.text = "스테이지 선택";
                break;
            case "CharacterForming":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[2].SetActive(true);
                UIList[5].SetActive(true);
                UIBtnControl.Add(UIList[5]);
                stageName.text = "캐릭터 편성";
                break;
            case "PowerUp":
                foreach (GameObject item in UIBtnControl)
                {
                    item.SetActive(false);
                }
                UIList[2].SetActive(true);
                UIList[6].SetActive(true);
                UIBtnControl.Add(UIList[6]);
                pUi.PowerUpUIinit();
                stageName.text = "파워 업";
                CheckUpGrade.instance.GetMyXp();

                break;
            case "BackSapce":
                UIBtnControl[UIBtnControl.Count - 1].SetActive(false);
                UIBtnControl.RemoveAt(UIBtnControl.Count - 1);
                UIBtnControl[UIBtnControl.Count - 1].SetActive(true);
                if(UIBtnControl[UIBtnControl.Count - 1].name == "Main")
                {
                    stageName.text = "고양이 기지";
                }
                if (UIBtnControl[UIBtnControl.Count - 1].name == "StageMask")
                {
                    SoundControll.instance.BackgoundSoundChange(0);
                }
                

                break;
            default:
                break;
        }
    }

    public void UpGrade()
    {
        int i = this.gameObject.GetComponent<UIScrollRectSnap>().minButtonNum;
        if (GameManager.instance.GetComponent<UserInfo>().userXp >= GameManager.instance.characterSlot[i].exp)
        {
            GameManager.instance.characterSlot[i].lv++;
            GameManager.instance.characterSlot[i].attack *= 2;
            GameManager.instance.characterSlot[i].hp *= 3;
            GameManager.instance.GetComponent<UserInfo>().MinusXp(GameManager.instance.characterSlot[i].exp);
            GameManager.instance.characterSlot[i].exp *= 2;

            CheckUpGrade.instance.GetMyXp();
            pUi.needXpText[i].text = GameManager.instance.characterSlot[i].exp.ToString();
        }
    }


}
