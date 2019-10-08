using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControll : MonoBehaviour {

    public List<string> texts;
    public Color pink;
    private Text Text;
    private int num = 0;

    private float changeTime = 0.15f;
    private float currentTime = 0;
    private void Start()
    {
        Text = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (currentTime >= changeTime)
        {
            currentTime -= changeTime * 2;
        }

        if (currentTime > 0.0f)
        {
            Text.color = Color.yellow;
        }
        else
        {
            Text.color = pink;
        }
        currentTime += Time.deltaTime;
        
    }


    public void NextClick()
    {
        num++;
        if (num == 3)
        {
            UIManager.instance.UIList[7].SetActive(false);
            UIManager.instance.OKButton();
            return;
        }
        SoundControll.instance.ClickSoundPlay(5);
        Text.text = texts[num];

    }

	IEnumerator Co_Delay()
    {
        yield return new WaitForSeconds(1.0f);
        Text.text = texts[num];
    }

}
