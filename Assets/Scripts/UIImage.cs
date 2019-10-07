using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour {

    public List<Image> images;
    public List<Text> needXpText;


    public void PowerUpUIinit()
    {
        ImageGet();
        XpText();
    }
    
    private void ImageGet()
    {
        Debug.Log("get Img");
        for (int i = 0; i < GameManager.instance.characterSize; i++)
        {
            images[i].sprite = GameManager.instance.characterSlot[i].monsterPowerUpIcon;
                //.Add(GameManager.instance.characterSlot[i].monsterIcon);
        }
    }

    private void XpText()
    {
        for (int i = 0; i < GameManager.instance.characterSize; i++)
        {
            needXpText[i].text = GameManager.instance.characterSlot[i].exp.ToString();
        }
    }

}
