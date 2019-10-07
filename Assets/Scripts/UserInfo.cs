using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    static public UserInfo instance;

    public Text xpText;
    public int userXp;

    public int castleHp;
    //public int castleDamage;

    public int moneyEfficiency;
    public int moneyMaxSize;




    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }
    
    private void Update()
    {
        xpText.text = userXp.ToString();
    }
    

    public void GetXp(int xp)
    {
        userXp += xp;
        xpText.text = userXp.ToString();
    }

    public void MinusXp(int xp)
    {
        userXp -= xp;
        xpText.text = userXp.ToString();
    }
 

}