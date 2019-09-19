using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutLineControll : MonoBehaviour {


    public Color outColor;

    public Outline Outline;

    public bool selectThis;


    public float changeTime = 0.2f;
    private float currentTime = 0.0f;
    public Color pink;

    private void Start()
    {
        Outline = this.gameObject.GetComponent<Outline>();

    }
     
    private void Update()
    {
        if (currentTime >= changeTime)
        {
            currentTime -= changeTime * 2;
        }
        if (selectThis)
        {
            if (currentTime > 0.0f)
            {
                Outline.effectColor = Color.yellow;
            }
            else
            {
                Outline.effectColor = pink;
            }
            currentTime += Time.deltaTime;
        }
    }


}
