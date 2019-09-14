using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildControll : MonoBehaviour {

    [SerializeField]
    public Vector2 cellSize, spacing;

    public List<GameObject> childSanpObject;

    private RectTransform nowRect;
    private void Start()
    {
        for (int i = 0; i < childSanpObject.Count; i++)
        {
            nowRect = childSanpObject[i].GetComponent<RectTransform>();
            nowRect.sizeDelta = cellSize;
            nowRect.anchoredPosition = new Vector2((cellSize.x + spacing.x) * i, 0);

        }
    }


}
