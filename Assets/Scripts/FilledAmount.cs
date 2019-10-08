using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledAmount : MonoBehaviour {

    private float delayCreateTime;
    private float currentTime;
    public Image image;
    
    private void Awake()
    {
        image = this.gameObject.GetComponent<Image>();
        image.fillAmount = 0;
    }

    //private void OnEnable()
    //{
        
    //}
    
    private void OnDisable()
    {
        currentTime = 0;
        image.fillAmount = 0;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        image.fillAmount = currentTime / delayCreateTime;
        if (image.fillAmount >= 1)
        {
            this.gameObject.SetActive(false);
            SoundControll.instance.ClickSoundPlay(3);
        }
        
    }
	
    public void getTime(int num)
    {
        delayCreateTime = num;
    }
}
