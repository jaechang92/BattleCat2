using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {

    //public value

    public int moveSpeed;
    public int hp;
    public int damage;
    public int range;
    public int attackDelay;

    public int objSizePer2;
    public GameObject rayPoint;

    public bool isEnemy = false;
    public string targetTag;
    public LayerMask targetMask;
    //private value

    public bool isMove = false;
    public Rigidbody2D rb;
    public Transform tr;
    public float currentTime;
    private Animator animator;




    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        tr = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        objSizePer2 = Mathf.CeilToInt(this.gameObject.GetComponent<RectTransform>().sizeDelta.x/2);
        Debug.Log(objSizePer2);




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


        currentTime += Time.deltaTime;
        if (currentTime > attackDelay)
        {
            currentTime = 0;
            
            animator.SetTrigger("Attacked");
        }

    }
    
    private void Move()
    {
        tr.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //Debug.Log("move");
    }

    private void SerachEnemy()
    {
        Vector2 origin;
        
        if (!isEnemy)
        {
            //origin = tr.position + objSizePer2 * Vector3.left;
            origin = rayPoint.transform.position;

        }
        else
        {
            origin = tr.position + objSizePer2 * Vector3.right;
        }
        
        Ray2D ray = new Ray2D(origin, Vector3.left);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.left, range, targetMask);
        Debug.DrawRay(ray.origin, Vector2.left * range, Color.red);
        
        if (hit)
        {
            Debug.Log(hit.collider.name);

        }
        if (hit && hit.collider.tag == targetTag)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
    }



}
