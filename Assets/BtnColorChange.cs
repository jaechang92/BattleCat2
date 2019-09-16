using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnColorChange : MonoBehaviour {

    public Sprite[] images;

    public Image image;
    

    private void OnEnable()
    {
        image = this.gameObject.GetComponent<Image>();

        StartCoroutine(ChageImage());
    }

    private void OnDisable()
    {
        StopCoroutine(ChageImage());
    }


    
    IEnumerator ChageImage()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);
        Debug.Log("코루틴시작");
        while (true)
        {
            if (image.sprite == images[0])
            {
                image.sprite = images[1];
            }
            else
            {
                image.sprite = images[0];
            }
            yield return waitTime;
        }
    }


}
