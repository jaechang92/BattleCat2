using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRectSnap : MonoBehaviour
{

    public RectTransform panel;
    public RectTransform panel2;
    public RectTransform panel3;
    public RectTransform panel4;
    public GameObject[] btn;
    public GameObject[] stageMaskBtn;

    public RectTransform center;
    public RectTransform center2;
    public RectTransform center3;
    public List<GameObject> charaterObj;
    public List<Button> characterBtn;
    public List<Image> images;
    public List<GameObject> powerUpBtn;

    public Button battleStartBtn;

    private float[] distance;
    private float[] smDistance;
    private float[] cDistance;
    private float[] pDistance;
    public bool dragging = false;
    private int btnDistance;
    private int stageMaskDistance;
    private int cBtnDistance;
    public int pBtnDistance;
    public int minButtonNum; // To hold the number of the button, with smallest distance to center

    private OutLineControll[] otcArray = new OutLineControll[3];

    private CreateObject obPool;

    public List<Image> slotImage; // 인게임슬롯이미지
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

        for (int i = 0; i < 3; i++)
        {
            otcArray[i] = stageMaskBtn[i].GetComponent<OutLineControll>();
        }


        int btnLenght = btn.Length;
        distance = new float[btnLenght];

        int btnLevelLenght = stageMaskBtn.Length;
        smDistance = new float[btnLevelLenght];

        int cBtnLenght = characterBtn.Count;
        cDistance = new float[cBtnLenght];

        int pBtnLenght = powerUpBtn.Count;
        pDistance = new float[pBtnLenght];

        btnDistance = (int)Mathf.Abs(btn[1].GetComponent<RectTransform>().anchoredPosition.x - btn[0].GetComponent<RectTransform>().anchoredPosition.x);
        stageMaskDistance = (int)Mathf.Abs(stageMaskBtn[1].GetComponent<RectTransform>().anchoredPosition.x - stageMaskBtn[0].GetComponent<RectTransform>().anchoredPosition.x);
        cBtnDistance = (int)Mathf.Abs(characterBtn[1].GetComponent<RectTransform>().anchoredPosition.x - characterBtn[0].GetComponent<RectTransform>().anchoredPosition.x);
        pBtnDistance = (int)Mathf.Abs(powerUpBtn[1].GetComponent<RectTransform>().anchoredPosition.x - powerUpBtn[0].GetComponent<RectTransform>().anchoredPosition.x);
        obPool = GameManager.instance.obPool.GetComponent<CreateObject>();

    }


    void Update()
    {


        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "BattelStage")
        {
            StageBtn();
        }

        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "StageMask")
        {
            StageMaskBtn();
        }

        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "CharacterFormingUI")
        {
            CharacterBtn();
        }

        if (UIManager.instance.UIBtnControl[UIManager.instance.UIBtnControl.Count - 1].name == "PoweUpMenu")
        {
            PowerUpBtn();
        }

    }

    public void PowerUpBtn()
    {
        for (int i = 0; i < powerUpBtn.Count; i++)
        {
            pDistance[i] = Mathf.Abs(center.transform.position.x - powerUpBtn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(pDistance); // Get the min distance

        for (int i = 0; i < powerUpBtn.Count; i++)
        {
            if (minDistance == pDistance[i])
            {

                minButtonNum = i;
                
                //InitSnap();
                //images[i].raycastTarget = true;
            }
        }

        if (!dragging)
        {
            LerpToBtn(panel4, minButtonNum * -pBtnDistance);
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
            LerpToBtn(panel2, minButtonNum * -cBtnDistance);
        }
    }

    public void StageMaskBtn()
    {
        for (int i = 0; i < stageMaskBtn.Length; i++)
        {
            smDistance[i] = Mathf.Abs(center3.transform.position.x - stageMaskBtn[i].transform.position.x);
        }
        float minDistance = Mathf.Min(smDistance); // Get the min distance
        
        for (int i = 0; i < stageMaskBtn.Length; i++)
        {
            if (minDistance == smDistance[i])
            {
                minButtonNum = i;

                foreach (var item in otcArray)
                {
                    item.selectThis = false;
                }
                otcArray[minButtonNum].selectThis = true;
            }
        }

        
        if (!dragging)
        {
            LerpToBtn(panel3, minButtonNum * -stageMaskDistance);
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
            LerpToBtn(panel,minButtonNum * -btnDistance);
        }
    }

    void LerpToBtn(RectTransform _panel, int position)
    {
        float newX = Mathf.Lerp(_panel.anchoredPosition.x, position, Time.deltaTime * 10f);

        Vector2 newPosition = new Vector2(newX, _panel.anchoredPosition.y);

        _panel.anchoredPosition = newPosition;
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

    public void StartBattle()
    {
        UIManager.instance.StageClick(minButtonNum);
        InitObjectPool();
    }

    private void InitObjectPool()
    {
        for (int i = 0; i < obPool.monster.Count; i++)
        {
            obPool.monster[i].GetComponent<CharacterState>().UpDateState(GameManager.instance.characterSlot[i]);
            slotImage[i].GetComponent<Image>().sprite = GameManager.instance.characterSlot[i].monsterIcon;
        }
    }

    
    

}
