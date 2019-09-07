using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour {

    public List<Sprite> images;

    private void Start()
    {
        GameManager.ImageUpdataEvent += ImageUpdate;
    }
    
    public void ImageUpdate()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i] = GameManager.instance.characterSlot[i].monsterIcon;
        }
    }
}
