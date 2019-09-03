using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public List<GameObject> monster;
    public RectTransform createPoint;

    public void SetUpMonster(List<CharacterState> States)
    {
        for (int i = 0; i < 5; i++)
        {
            monster[i].GetComponent<CharacterState>().moveSpeed = States[i].moveSpeed;
            monster[i].GetComponent<CharacterState>().hp = States[i].hp;
            monster[i].GetComponent<CharacterState>().damage = States[i].damage;
            monster[i].GetComponent<CharacterState>().range = States[i].range;
            monster[i].GetComponent<CharacterState>().attackDelay = States[i].attackDelay;
        }
    }

    public void CreateMonster(int num)
    {
        if (GameManager.instance.characterSlot[num].cost < GameManager.instance.money)
        {
            GameObject obj = Instantiate(monster[num], this.gameObject.transform);
            obj.GetComponent<RectTransform>().anchoredPosition = createPoint.anchoredPosition;
            CharacterState characterState = obj.GetComponent<CharacterState>();
            characterState = GameManager.instance.characterSlot[num];
            GameManager.instance.money -= GameManager.instance.characterSlot[num].cost;
        }

    }
}
