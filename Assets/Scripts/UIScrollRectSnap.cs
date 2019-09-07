using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRectSnap : MonoBehaviour
{

    public RectTransform panel;
    public RectTransform panel2;
    public Button[] btn;
    public RectTransform center;
    public RectTransform center2;
    public List<GameObject> charaterObj;
    public List<Button> characterBtn;
    public List<Image> images;


    private float[] distance;
    private float[] cDistance;
    public bool dragging = false;
    private int btnDistance;
    private int cBtnDistance;
    private int minButtonNum; // To hold the number of the button, with smallest distance to center

    void Start()
    {
        foreach (var item in charaterObj)
        {
            characterBtn.Add(item.GetComponent<Button>());
            images.Add(item.GetComponent<Image>());
        }
        


        foreach (var item in images)
        {
            item.raycastTarget = false;
        }

        int btnLenght = btn.Length;
        distance = new float[btnLenght];

        int cBtnLenght = characterBtn.Count;
        cDistance = new float[cBtnLenght];

        btnDistance = (int)Mathf.Abs(btn[1].GetComponent<RectTransform>().anchoredPosition.x - btn[0].GetComponent<RectTransform>().anchoredPosition.x);
        cBtnDistance = (int)Mathf.Abs(characterBtn[1].GetComponent<RectTransform>().anchoredPosition.x - characterBtn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }


    void Update()
    {


        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "BattelStage")
        {
            StageBtn();
        }

        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "CharacterFormingUI")
        {
            CharacterBtn();
        }


    }

    public void CharacterBtn()
    {
        for (int i = 0; i < characterBtn.Count; i++)
        {
            cDistance[i] = Mathf.Abs(center2.transform.position.x - characterBtn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(cDistance); // Get the min distance

        for (int i = 0; i < characterBtn.Count; i++)
        {
            if (minDistance == cDistance[i])
            {
                minButtonNum = i;
                InitSnap();
                images[i].raycastTarget = true;
            }
        }
        
        if (!dragging)
        {
            LerpToBtn2(minButtonNum * -cBtnDistance);
        }
    }

    public void StageBtn()
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

        if (!dragging)
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
    void LerpToBtn2(int position)
    {

        float newX = Mathf.Lerp(panel2.anchoredPosition.x, position, Time.deltaTime * 10f);

        Vector2 newPosition = new Vector2(newX, panel2.anchoredPosition.y);

        panel2.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {

        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }



    public void InitSnap()
    {
        foreach (var item in images)
        {
            item.raycastTarget = false;
        }

    }

}
