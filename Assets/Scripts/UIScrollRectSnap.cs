using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRectSnap : MonoBehaviour
{
    public RectTransform panel;
    public Button[] btn;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int btnDistance;
    private int minButtonNum; // To hold the number of the button, with smallest distance to center

    void Start()
    {
        int btnLenght = btn.Length;
        distance = new float[btnLenght];

        btnDistance = (int)Mathf.Abs(btn[1].GetComponent<RectTransform>().anchoredPosition.x - btn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }


    void Update()
    {
        for (int i = 0; i < btn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - btn[i].transform.position.x);
        }
        
        float minDistance = Mathf.Min(distance); // Get the min distance

        for (int i = 0; i < btn.Length; i++)
        {
            if (minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }

        if(!dragging)
        {
            LerpToBtn(minButtonNum * -btnDistance);
        }


    }

    void LerpToBtn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);

        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

}
