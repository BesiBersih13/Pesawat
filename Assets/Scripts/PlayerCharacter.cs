using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	
    //////////////////////////////
    //      PUBLIC VARIABLES    //
    //////////////////////////////
    public float moveSpeed = 7;
 

    //////////////////////////////
    //      PRIVATE VARIABLES   //
    //////////////////////////////
    
    // Variabel yang menunjukkan arah gerak horizontal pemain
    private float moveDirectionX;
    private float moveDirectionY;

    // Referensi terhadap komponen rigidbody pemain
    private Rigidbody2D rb2d;

    // Referensi terhadap komponen sprite pemain
    private SpriteRenderer spr;

    private bool canAttack;

    private MissileScripts missileScripts;

    private HealthScript health;

    // Start - dijalankan pada awal dijalankannya script ini
    // alias pada konteks ini saat awal permainan
     void Start()
    {
        // Menyimpan referensi komponen Rigidbody 2D & Sprite
        rb2d = GetComponent<Rigidbody2D>();

        spr = GetComponent<SpriteRenderer>();

        health = GetComponent<HealthScript>();
    }
        

    // FixedUpdate - dijalankan setiap 1/50 detik (nilai default, dapat dikonfigurasi)
     void Update(){

     }
     
     void FixedUpdate()
    {
        // Menyimpan arah derak player
        moveDirectionX = Input.GetAxis("Horizontal");
        moveDirectionY = Input.GetAxis("Vertical");
        canAttack = Input.GetButtonDown("Fire1");

        // Menge-flip sprite ketika menghadap kiri-kanan
        // & menjalankan animasi gerak
        if (moveDirectionX > 0)
        {
            spr.flipX = false;
        }
        else if (moveDirectionX < 0)
        {
            spr.flipX = true;
        }
        else    // moveDirection == 0
        {
        }

        // Menghitung kecepatan gerak pemain
        rb2d.velocity = new Vector2(moveDirectionX * moveSpeed, moveDirectionY * moveSpeed);
        
        if(canAttack){
            Attack();
        }
    }
    
    void OnCollisionEnter2D(Collision col)
    {
        int damage = 0;
        MissileController missileController = col.gameObject.GetComponent<MissileController>();
        EnemyCharacter enemyCharacter = col.gameObject.GetComponent<EnemyCharacter>();
        
        if(missileController){
            if(!missileController.IsUsedByPlayer()){
                damage = col.gameObject.GetComponent<MissileController>().damage;
            }
        } else if (enemyCharacter){
            damage = 1;
        }
        }

        health.Damage(damage);
    }

    void Attack(){
        missileScript.SummonMissile(false);
    }
}