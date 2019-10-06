using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameManager instance;
    public UIScrollRectSnap _UI;

    public delegate void EventHandler();
    


    private struct UserStatus
    {
        public int Magnification_UserMoneySpeed;
        public int Magnification_UserCreateSpeed;
        public int Magnification_UserMoneySize;
        public int UserCatstleHp;
    }

    public float money;
    public Text moneyText;

    public Text mainDescriptionText;
    public List<string> descriptionText;
    public Text powerUpDescriptionText;

    private int lastnum;

    private UserStatus userStatus;

    public int characterSize = 4;
    public List<Monster> characterSlot;


    public List<GameObject> slot;

    public GameObject obPool;


    public void initAll()
    {
        
        money = 0;
        userStatus.UserCatstleHp = 5000;
        userStatus.Magnification_UserMoneySpeed = 200;
        userStatus.Magnification_UserMoneySize = 2000;
        userStatus.Magnification_UserCreateSpeed = 1;

        for (int i = 0; i < characterSize; i++)
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

        for (int i = 0; i < 5; i++)
        {
            slot[i].GetComponent<Image>().sprite = characterSlot[i].monsterIcon;
            Debug.Log(characterSlot[i].monsterIcon.name);
        }


    }

    private void Update()
    {
        CalculMoney();
       
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

        moneyText.text = (int)money + "/" + userStatus.Magnification_UserMoneySize;
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
}
