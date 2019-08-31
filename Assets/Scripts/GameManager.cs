using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public GameManager instance;

    private struct UserStatus
    {
        public int Magnification_UserMoneySpeed;
        public int Magnification_UserCreateSpeed;
        public int Magnification_UserMoneySize;
        public int UserCatstleHp;
    }

    public float money;
    private UserStatus userStatus;

    public List<CharacterState> characterSlot;




    private void initAll()
    {
        money = 0;
        userStatus.UserCatstleHp = 5000;
        userStatus.Magnification_UserMoneySpeed = 200;
        userStatus.Magnification_UserMoneySize = 2000;
        userStatus.Magnification_UserCreateSpeed = 1;
        Debug.Log("초기화");
    }

    private void Start()
    {
        instance = this;
        initAll();
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
    }

}
