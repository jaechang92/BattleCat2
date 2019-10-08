using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVupChange : MonoBehaviour {
    public Image myImage;

    public List<Sprite> images;

    public List<int> lvUpCost;
    public List<Text> texts;
    
    private int lv = 1;
    private int maxLv = 3;
	// Use this for initialization
	void Start () {
        myImage = this.GetComponent<Image>();

    }

    

    // Update is called once per frame
    void Update()
    {

        if (lv < maxLv)
        {
            if (lvUpCost[lv - 1] <= GameManager.instance.money)
            {
                myImage.sprite = images[1];
                texts[0].color = Color.white;
            }
            else
            {
                texts[0].color = Color.gray;
                myImage.sprite = images[0];
            }
        }
        else
        {
            myImage.sprite = images[1];
        }

    }

    public void Init()
    {
        lv = 1;
        texts[0].text = lv.ToString();
        texts[1].text = lvUpCost[lv - 1].ToString() + "원";
    }

    public void ClickLvUp()
    {
        if (lv < maxLv)
        {
            if (myImage.sprite.name == images[1].name)
            {
                GameManager.instance.money -= lvUpCost[lv - 1];
                lv++;
                if (lv == maxLv)
                {
                    texts[0].text = lv.ToString();
                    texts[1].text = "MAX";
                }
                else
                {
                    texts[0].text = lv.ToString();
                    texts[1].text = lvUpCost[lv - 1].ToString() + "원";
                }
                GameManager.instance.userStatus.Magnification_UserMoneySpeed *= 2;
                GameManager.instance.userStatus.Magnification_UserMoneySize *= 2;
                SoundControll.instance.ClickSoundPlay(1);
            }
        }
    }


}
