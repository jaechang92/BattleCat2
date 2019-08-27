using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour {

    //public value

    public int moveSpeed;
    [Range(0,50000)]
    public int hp;
    public int damage;
    public int range;
    public int attackDelay;
    public bool isDie = false;

    public int objSizePer2;
    public GameObject rayPoint;

    public bool isEnemy = false;
    public string targetTag;
    public LayerMask targetMask;
    public bool isTower = false;
    //private value

    public bool isMove = false;
    public Rigidbody2D rb;
    public Transform tr;
    public float currentTime;

    public Animator animator;

    Ray2D ray;
    public RaycastHit2D[] hitAll;
    public Text towerText;
    private int maxHp;

    private void Start()
    {
        animator = this.gameObject.GetComponentInChildren<Animator>();
        tr = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        objSizePer2 = Mathf.CeilToInt(this.gameObject.GetComponent<RectTransform>().sizeDelta.x/2);
        maxHp = hp;

        if (isTower)
        {
            towerText = GetComponentInChildren<Text>();
        }



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
        currentTime += Time.deltaTime;

        SerachEnemy();

        if (isMove)
        {
            Move();
        }

        if (isTower && UIManager.instance.ativeStage != -1)
        {
            towerText.text = hp + "/" + maxHp;
            if (hp == 0)
            {
                UIManager.instance.EndStage();
                
            }
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
        
        ray = new Ray2D(origin, Vector3.left);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.left, range, targetMask);
        Debug.DrawRay(ray.origin, Vector2.left * range, Color.red);
       
        if (hit && hit.collider.tag == targetTag)
        {
            isMove = false;
            Attacked();
        }
        else
        {
            isMove = true;
        }
    }

    private void Attacked()
    {
        if (currentTime > attackDelay)
        {
            currentTime = 0;
            animator.SetTrigger("Attacked");
            Debug.Log("공격");
            hitAll = Physics2D.RaycastAll(ray.origin, Vector2.left, range, targetMask);
            GetDamageAll();
        }
    }

    private void GetDamageAll()
    {
        foreach (var item in hitAll)
        {
            item.collider.SendMessage("OtherHit", damage,SendMessageOptions.DontRequireReceiver);
        }
    }


    private void OtherHit(int damage)
    {
        Debug.Log("Hit");
        this.hp -= damage;
        

        if (hp <= 0  && !isTower)
        {
            DieAnimation();
        }
    }

    private void DieAnimation()
    {
        animator.SetTrigger("Die");
        isDie = true;
        Debug.Log("Die");
    }

    public void Destroyed()
    {
        Destroy(this.gameObject);
    }
}
