using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameManager instance;
    public UIScrollRectSnap _UI;

    public delegate void EventHandler();
    


    public struct UserStatus
    {
        public int Magnification_UserMoneySpeed;
        public int Magnification_UserCreateSpeed;
        public int Magnification_UserMoneySize;
        public int UserCatstleHp;
    }
    public bool gameStart;
    public float money;
    public Text moneyText;

    public Text mainDescriptionText;
    public List<string> descriptionText;
    public Text powerUpDescriptionText;

    private int lastnum;

    public UserStatus userStatus;

    public int characterSize = 1;
    public List<Monster> characterSlot;


    public List<GameObject> slot;

    public GameObject obPool;
    public bool isTutorial = true;
    public bool tutorialStart = false;
    public Text tutorialDescriptionText;
    public List<string> tutorialText;
    public GameObject tutorialFilter;
    public int tutorialNum = 0;
    public GameObject arrowDown;
    public GameObject arrowUp;
    public List<Vector2> arrowPosList;

    public LVupChange LVupChange;
    public void initAll()
    {
        
        money = 0;
        userStatus.UserCatstleHp = 5000;
        userStatus.Magnification_UserMoneySpeed = 5;
        userStatus.Magnification_UserMoneySize = 1000;
        userStatus.Magnification_UserCreateSpeed = 1;

        for (int i = 0; i <= characterSize; i++)
        {
            characterSlot.Add(Database.instance.myMonsterList[i]);
            
            _UI.images[i].sprite = Database.instance.myMonsterList[i].monsterIcon;
            

        }

        
        Debug.Log("초기화");
    }

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        initAll();

        for (int i = 0; i <= 0; i++)
        {
            slot[i].GetComponent<Image>().sprite = characterSlot[i].monsterIcon;
            Debug.Log(characterSlot[i].monsterIcon.name);
        }


    }

    private void Update()
    {
        CalculMoney();

        if (isTutorial && tutorialStart)
        {
            if (tutorialNum == 0)
            {
                tutorialFilter.SetActive(true);
                Time.timeScale = 0;
                tutorialDescriptionText.text = tutorialText[0];
                StartCoroutine(Co_Tutorial(2.0f));
            }
            if (money >= 75 && tutorialNum == 2)
            {
                tutorialFilter.SetActive(true);
                Time.timeScale = 0;
                tutorialDescriptionText.text = tutorialText[2];

                arrowUp.SetActive(true);
                arrowUp.GetComponent<RectTransform>().anchoredPosition = arrowPosList[1];
            }
            if (tutorialNum == 3)
            {
                tutorialFilter.SetActive(true);
                Time.timeScale = 0;
                tutorialDescriptionText.text = tutorialText[3];
                StartCoroutine(Co_Tutorial(10.0f));

                arrowDown.SetActive(true);
                arrowUp.SetActive(true);
            }
            if (tutorialNum == 5)
            {
                tutorialFilter.SetActive(true);
                Time.timeScale = 0;
                tutorialDescriptionText.text = tutorialText[5];

                arrowDown.SetActive(true);
                arrowUp.SetActive(true);
            }
        }
    }

    private void CalculMoney()
    {
        if (userStatus.Magnification_UserMoneySize > money)
        {
            money += userStatus.Magnification_UserMoneySpeed * Time.deltaTime;
        }
        else
        {
            money = userStatus.Magnification_UserMoneySize;
        }

        moneyText.text = (int)money + "/" + userStatus.Magnification_UserMoneySize + "원";
    }

    public void GetMonster(int id)
    {
        Monster monster = Database.instance.MyMonsterFindFunc(id);
        if (monster != null)
        {
            characterSize++;
            characterSlot.Add(monster);
        }
    }

    public void MainDescriptionTextClick()
    {
        int rand = Random.Range(0, descriptionText.Count - 1);
        while (lastnum == rand)
        {
            rand = Random.Range(0, descriptionText.Count - 1);
        }
        lastnum = rand;
        mainDescriptionText.text = descriptionText[lastnum];
    }



    public void Tutorial()
    {
        
        Debug.Log("튜토리얼이 실행중입니다.");
    }

    IEnumerator Co_Tutorial(float time)
    {
        yield return new WaitForSeconds(time);
        tutorialFilter.SetActive(true);
        Time.timeScale = 0;
        if (tutorialNum == 1)
        {
            tutorialDescriptionText.text = tutorialText[1];
            arrowDown.SetActive(true);
            arrowDown.GetComponent<RectTransform>().anchoredPosition = arrowPosList[0];
        }
        if (tutorialNum == 4)
        {
            tutorialDescriptionText.text = tutorialText[4];
            arrowDown.SetActive(true);
            arrowDown.GetComponent<RectTransform>().anchoredPosition = arrowPosList[2];
            arrowUp.SetActive(true);
        }
    }
}
