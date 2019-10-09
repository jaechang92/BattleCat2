using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundControll : MonoBehaviour
{
    public CharacterState rootCharacterState;


    
    public void PlayAttackSound()
    {
        rootCharacterState.GetDamageAll();
        SoundControll.instance.HitSoundPlay(1);
    }

    public void Destory()
    {
        Destroy(this.gameObject);
    }
}
