using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public List<GameObject> monster;
    public RectTransform createPoint;

    public void CreateMonster(int num)
    {
        GameObject obj = Instantiate(monster[num], this.gameObject.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = createPoint.anchoredPosition;

    }
}
