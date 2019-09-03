using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanpControll : MonoBehaviour {

    public List<Image> images;

    private void Start()
    {
        foreach (var item in images)
        {
            item.raycastTarget = false;
        }
    }

    private void Update()
    {

    }

}
