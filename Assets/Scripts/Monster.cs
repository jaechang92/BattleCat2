using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Monster
{

    public int monsterID; // 몬스터의 고유 ID값. 중복 불가능
    public string monsterName; // 몬스터의 이름. 중복 가능.
    public string monsterDescription; // 몬스터의 설명

    public Sprite monsterIcon; // 몬스터의 아이콘.
    public GameObject monsterPrefab;

    public int lv;
    public int exp;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public int critical;
    public int maxExp;
    public int cost;


    public Monster(int _monsterID, string _monsterName, string _monsterDes, int _lv, int _exp, int _hp, int _attack, int _defense, int _speed, int _critical , int _cost)
    {
        monsterName = _monsterName;
        monsterDescription = _monsterDes;
        
        lv = _lv;
        exp = _exp;
        hp = _hp;
        attack = _attack;
        defense = _defense;
        speed = _speed;
        critical = _critical;
        cost = _cost;
        maxExp = _lv * 1000;

        //monsterIcon = Resources.Load("Images/MonsterIcon/" + monsterID.ToString(), typeof(Sprite)) as Sprite;
        //monsterPrefab = Resources.Load("Prefabs/Model/" + monsterID.ToString(), typeof(GameObject)) as GameObject;
        //Debug.Log(monsterPrefab);
    }

    public Monster MonsterDeepCopy()
    {
        Monster newCopy = new Monster(monsterID, monsterName, monsterDescription, lv, exp, hp, attack, defense, speed, critical, cost);

        newCopy.monsterID = this.monsterID;
        newCopy.monsterName = this.monsterName;
        newCopy.monsterDescription = this.monsterDescription;
        newCopy.lv = this.lv;
        newCopy.exp = this.exp;
        newCopy.hp = this.hp;
        newCopy.attack = this.attack;
        newCopy.defense = this.defense;
        newCopy.speed = this.speed;
        newCopy.critical = this.critical;
        newCopy.cost = this.cost;
        newCopy.maxExp = this.maxExp;
        return newCopy;
    }



}
