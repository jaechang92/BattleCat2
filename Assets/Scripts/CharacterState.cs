using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour {

    //public value

    public float moveSpeed;
    [Range(0,50000)]
    public int hp;
    public int damage;
    public float range;
    public int attackDelay;
    public int rewardMoney;
    public int cost;
    public int createTime;
    public GameObject prefab;
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
    public bool isRight = false;

    public void StartBattle()
    {
        initState();
    }

    private void initState()
    {
        isDie = false;
        hp = maxHp;
    }

    public void initState(int num)
    {
        
        isDie = false;
        hp = GameManager.instance.characterSlot[num].hp;
        damage = GameManager.instance.characterSlot[num].attack;

        if (isRight)
        {
            this.gameObject.transform.localScale.Set(-1,1,1);
            //range = -GameManager.instance.characterSlot[num].range;
            moveSpeed = -GameManager.instance.characterSlot[num].speed;
            this.gameObject.layer = 10;
            this.gameObject.tag = "Enemy";
            targetMask = 1 << 9;
        }
        else
        {
            range = GameManager.instance.characterSlot[num].range;
            moveSpeed = GameManager.instance.characterSlot[num].speed;
        }

    }


    private void Start()
    {
        animator = this.gameObject.GetComponentInChildren<Animator>();
        tr = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        //objSizePer2 = Mathf.CeilToInt(this.gameObject.GetComponent<RectTransform>().sizeDelta.x/2);
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


        UIManager.StartGameEvnet += StartBattle;

        
    }


    private void Update()
    {
        currentTime += Time.deltaTime;
        if (!this.gameObject.CompareTag("Slot"))
        {
            SerachEnemy();
        }

        if (isMove)
        {
            Move();
        }

        if (isTower && UIManager.instance.ativeStage != -1 && isEnemy && !isDie)
        {
            towerText.text = hp + "/" + maxHp;
            if (hp <= 0)
            {
                hp = 0;
                GameManager.instance.moneyText.gameObject.SetActive(false);
                UIManager.instance.UIList[4].SetActive(true);
                UIManager.instance.GetMoney(rewardMoney);
                UserInfo.instance.GetXp(rewardMoney);
                isDie = true;
                SoundControll.instance.GetComponent<AudioSource>().clip = null;
                SoundControll.instance.ClickSoundPlay(4);
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
        origin = rayPoint.transform.position;
        if (!isEnemy)
        {
            //origin = tr.position + objSizePer2 * Vector3.left;
            ray = new Ray2D(origin, Vector3.left);

        }
        else
        {
            ray = new Ray2D(origin, Vector3.right);
        }
        

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, range, targetMask);
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
        if (isTower)
        {
            isMove = false;
        }
        else
        {
            

            if (hit && hit.collider.tag == targetTag)
            {
                
                isMove = false;
                animator.SetBool("IsWalk", false);
                Attacked();
            }
            else
            {
                isMove = true;
                animator.SetBool("IsWalk", true);
            }
        }
    }

    public void Attacked()
    {
        if (currentTime > attackDelay)
        {
            currentTime = 0;
            animator.SetTrigger("Attacked");
            Debug.Log("공격");
            hitAll = Physics2D.RaycastAll(ray.origin, Vector2.left, range, targetMask);
            //GetDamageAll();
        }
    }

    public void GetDamageAll()
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
        if (isTower)
        {
            SoundControll.instance.HitSoundPlay(0);
        }
        
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

    public void UpDateState(Monster monster)
    {
        moveSpeed = monster.speed;
        hp = monster.hp;
        damage = monster.attack;
        range = monster.range;
        attackDelay = monster.attackDelay;
        cost = monster.cost;
        createTime = monster.createTime;
        prefab = monster.monsterPrefab;
    }

    

}
