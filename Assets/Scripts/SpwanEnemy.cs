using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour {

    public List<GameObject> enemys;


    public float spwanTime;
    public float currentTime = 0;


    private Vector3 Vector3;
	// Use this for initialization
	void Start () {
        Vector3 = new Vector3(-5, -2, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameStart)
        {
            if (currentTime > spwanTime)
            {
                float rand = Random.Range(0, (float)200 / 1000);
                Vector3 rVector = new Vector2(0, rand);

                GameObject obj = Instantiate(enemys[0]);
                obj.GetComponent<Transform>().position = Vector3 + rVector;

                obj.GetComponent<CharacterState>().isRight = true;
                obj.GetComponent<CharacterState>().isEnemy = true;
                obj.GetComponent<CharacterState>().initState(0);
                obj.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)(rand * -100000);
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }

            
        }
	}
}
