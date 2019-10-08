using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour {

    public List<GameObject> monster;
    public Transform createPoint;

    public List<GameObject> createMonster;
    public List<Image> slotImage; // 인게임슬롯이미지
    public List<Image> gage;


    private Color waitColor = Color.gray;
    private Color originColor = Color.white;
    public int deltaH;
    private void Start()
    {
        UIManager.EndGameEvent += EndGame;
    }


    //public void SetUpMonster(List<CharacterState> States)
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        monster[i].GetComponent<CharacterState>().moveSpeed = States[i].moveSpeed;
    //        monster[i].GetComponent<CharacterState>().hp = States[i].hp;
    //        monster[i].GetComponent<CharacterState>().damage = States[i].damage;
    //        monster[i].GetComponent<CharacterState>().range = States[i].range;
    //        monster[i].GetComponent<CharacterState>().attackDelay = States[i].attackDelay;
    //    }
    //}

    public void CreateMonster(int num)
    {
        if (slotImage[num].GetComponent<Image>().sprite.name == "빈 생산박스")
        {
            return;
        }
        float rand = Random.Range(0, (float)deltaH/1000);
        Vector3 rVector = new Vector2(0, rand);
        int _cost = monster[num].GetComponent<CharacterState>().cost;
        if (_cost < GameManager.instance.money && slotImage[num].GetComponent<Image>().color != waitColor)
        {
            SoundControll.instance.ClickSoundPlay(0);
            SoundControll.instance.ClickSoundPlay(1, 0.2f);
            GameObject obj = Instantiate(monster[num].GetComponent<CharacterState>().prefab, this.gameObject.transform);
            obj.GetComponent<Transform>().position = createPoint.position + rVector;
            obj.GetComponent<CharacterState>().initState(num);

            GameManager.instance.money -= _cost;
            createMonster.Add(obj);

            obj.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)(rand * -100000);

            slotImage[num].GetComponent<Image>().color = waitColor;
            StartCoroutine(CreateActive(num));
            gage[num].gameObject.SetActive(true);
            gage[num].GetComponent<FilledAmount>().getTime(monster[num].GetComponent<CharacterState>().createTime);
        }

    }

    public void EndGame()
    {
        foreach (var item in createMonster)
        {
            Destroy(item);
        }
        createMonster.Clear();
    }

    IEnumerator CreateActive(int num)
    {
        int waitTime = monster[num].GetComponent<CharacterState>().createTime;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("코루틴");
        slotImage[num].GetComponent<Image>().color = originColor;
    }

}
