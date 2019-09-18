using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnColorChange : MonoBehaviour {

    public Sprite[] images;

    public Image image;

    public int delayTime;
    public bool onOff;

    private void OnEnable()
    {
        image = this.gameObject.GetComponent<Image>();

        if (!onOff)
        {
            StartCoroutine(ChageImage());
        }
    }

    private void OnDisable()
    {
        image.sprite = images[0];
        StopCoroutine(ChageImage());
    }

    public void ChageOn()
    {
        StartCoroutine(ChageImage());
    }

    IEnumerator ChageImage()
    {
        float wfst = 0.1f;
        WaitForSeconds waitTime = new WaitForSeconds(wfst);
        float wt = 0;
        Debug.Log("코루틴시작");
        while (delayTime >= wt)
        {
            if (image.sprite == images[0])
            {
                image.sprite = images[1];
            }
            else
            {
                image.sprite = images[0];
            }
            wt += wfst;
            yield return waitTime;
        }
    }


}
