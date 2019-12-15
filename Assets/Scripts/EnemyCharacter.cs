using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private MissileScripts missileScript;

    public float cooldown = 2f;

    void Start(){
        missileScript = GetComponent<MissileScripts>();
        float delay = cooldown;
    }

    void Update()
    {
        delay -= Time.deltaTime;

        if(delay <= 0){
            delay = cooldown;
            Attack();
        }
    }

    void Attack(){
        missileScript.SummonMissile(false);
    }
}