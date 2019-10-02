using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildControll : MonoBehaviour {

    [SerializeField]
    public Vector2 cellSize, spacing;
    public Vector2 TestSize;
    public List<GameObject> childSanpObject;
    public List<RectTransform> csro;
    private RectTransform nowRect;
    private UIScrollRectSnap usrs;
    public int num;
    private void Start()
    {
        for (int i = 0; i < childSanpObject.Count; i++)
        {
            csro.Add(childSanpObject[i].GetComponent<RectTransform>());
        }

        for (int i = 0; i < childSanpObject.Count; i++)
        {
            nowRect = csro[i];
            nowRect.sizeDelta = cellSize;
            nowRect.anchoredPosition = new Vector2((cellSize.x + spacing.x) * i, 0);
        }
        usrs = UIManager.instance.GetComponent<UIScrollRectSnap>();
        
    }

    private void Update()
    {
        num = usrs.minButtonNum;
        for (int i = 0; i < childSanpObject.Count; i++)
        {
            if (i == num)
            {
                csro[i].sizeDelta = cellSize + TestSize;
            }
            else
            {
                csro[i].sizeDelta = cellSize;
            }
        }
    }


}
