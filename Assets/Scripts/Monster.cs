using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Monster
{

    public int monsterID; // 몬스터의 고유 ID값. 중복 불가능
    public string monsterName; // 몬스터의 이름. 중복 가능.
    public string monsterDescription; // 몬스터의 설명

    public Sprite monsterPowerUpIcon; // 몬스터의 기본 아이콘.
    public Sprite monsterIcon; // 몬스터의 금액 아이콘.
    public GameObject monsterPrefab;

    public int lv;
    public int exp;
    public int hp;
    public int attack;
    public int range;
    public int defense;
    public int speed;
    public int attackDelay;
    public int critical;
    public int maxExp;
    public int cost;
    public int createTime;


    public Monster(int _monsterID, string _monsterName, string _monsterDes, int _lv, int _exp, int _hp, int _attack, int _defense, int _speed, int _critical ,int _range, int _attackDelay, int _cost, int _createTime)
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
        attackDelay = _attackDelay;
        range = _range;
        cost = _cost;
        maxExp = _lv * 1000;
        createTime = _createTime;
        //monsterIcon = Resources.Load("Images/MonsterIcon/" + monsterID.ToString(), typeof(Sprite)) as Sprite;
        //monsterPrefab = Resources.Load("Prefabs/Model/" + monsterID.ToString(), typeof(GameObject)) as GameObject;
        //Debug.Log(monsterPrefab);
    }

    public Monster MonsterDeepCopy()
    {
        Monster newCopy = new Monster(monsterID, monsterName, monsterDescription, lv, exp, hp, attack, defense, speed, critical, attackDelay, range, cost, createTime);

        newCopy.monsterID = this.monsterID;
        newCopy.monsterName = this.monsterName;
        newCopy.monsterDescription = this.monsterDescription;
        newCopy.lv = this.lv;
        newCopy.exp = this.exp;
        newCopy.hp = this.hp;
        newCopy.attack = this.attack;
        newCopy.defense = this.defense;
        newCopy.speed = this.speed;
        newCopy.attackDelay = this.attackDelay;
        newCopy.critical = this.critical;
        newCopy.range = this.range;
        newCopy.cost = this.cost;
        newCopy.maxExp = this.maxExp;
        newCopy.createTime = this.createTime;
        return newCopy;
    }



}
