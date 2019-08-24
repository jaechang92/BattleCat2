using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {

    //public value

    public int moveSpeed;
    public int hp;
    public int damage;
    public int range;

    public bool isEnemy = false;
    public string targetTag;
    //private value

    public bool isMove = false;
    public Rigidbody2D rb;
    public Transform tr;





    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        if (!isEnemy)
        {
            targetTag = "Enemy";
        }
        else
        {
            targetTag = "Player";
        }
    }


    private void Update()
    {
        SerachEnemy();

        if (isMove)
        {
            Move();
        }

    }
    
    private void Move()
    {
        tr.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //Debug.Log("move");
    }

    private void SerachEnemy()
    {
        Vector2 origin = tr.position;
        Ray2D ray = new Ray2D(tr.position, Vector3.left);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.left,range);
        Debug.DrawRay(ray.origin, Vector2.left * range, Color.red);

        if (hit.collider.tag == targetTag)
        {
            Debug.Log(hit.collider.name);
            isMove = false;
        }
        else
        {
            isMove = true;
        }
    }

}
