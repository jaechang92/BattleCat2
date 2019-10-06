using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotImage : MonoBehaviour {

    public Image img;

    private void Update()
    {
        GetImage();
    }

    public void GetImage()
    {
        //Debug.Log("좌표 = " + this.GetComponent<RectTransform>().localPosition);
    }
	
}
