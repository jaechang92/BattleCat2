using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour {

    public List<Image> images;

    
    public void ImageGet()
    {
        Debug.Log("get Img");
        for (int i = 0; i < GameManager.instance.characterSize; i++)
        {
            images[i].sprite = GameManager.instance.characterSlot[i].monsterIcon;
                //.Add(GameManager.instance.characterSlot[i].monsterIcon);
        }
    }
}
