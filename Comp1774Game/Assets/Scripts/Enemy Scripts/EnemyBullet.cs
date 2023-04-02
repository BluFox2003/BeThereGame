using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    int damageAmount = 1;
    [SerializeField] LayerMask playerLayer, wallLayer;
    bool shotPlayer;

    // private void OnTriggerEnter2D(Collider2D collision) {
    //     PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
    //     if(playerHealth != null){

    //         playerHealth.DealDamage(damageAmount);
    //         Destroy(gameObject);
    //     }
    // }

    bool CheckCollison(LayerMask l){
        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, l);
        if (col){
            if(l == playerLayer){
                col.gameObject.GetComponent<PlayerHealth>().DealDamage(damageAmount);
                Destroy(gameObject);
            }
            return true;
        }
        else if(col){
            if(l == wallLayer){
                Destroy(gameObject);
            }
            return true;
        }
    
        else {
            return false;
        }}
    
    void Update(){
        ShotPlayer();
        ShotWall();
    }

    void ShotWall(){
        if(CheckCollison(wallLayer)){
            Destroy(gameObject);
        }
    }
    void ShotPlayer(){
        shotPlayer = CheckCollison(playerLayer);
    }



}
