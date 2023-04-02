using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyController enemyController;
    enum AIState {Idle, Attack};
    AIState aiState;
    GameObject playerTarget;
    [SerializeField] float attackRange = 3f;
    float distanceToPlayer;
    EnemyWeapon enemyWeapon;
    public static Vector3 directionToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyWeapon = GetComponent<EnemyWeapon>();
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerTarget != null){
            directionToPlayer = playerTarget.transform.position - transform.position;
            // Get the distance between the player and the enemy
            distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);
            // If the distance is less than attack range, then the enemy should attack
            if (distanceToPlayer < attackRange){
                aiState = AIState.Attack;
            } else {
                aiState = AIState.Idle;
            }
            if (aiState == AIState.Idle){
                StopMoving();

            } else if (aiState == AIState.Attack){
                enemyWeapon.Shoot(directionToPlayer.x, directionToPlayer.y);
                MoveToPlayer();

                
            }
    
        }
        else {
            //stops enemies moving when player dead
            StopMoving();
        }
    }

    public void StopMoving(){
        enemyController.ControlNPC(0f, 0f);
    }

    

    void MoveToPlayer(){
        if (playerTarget != null){
                // Move towards the player
                // Get the direction to the player
                LookAtPlayer();
                // Move the enemy in that direction
                enemyController.ControlNPC(directionToPlayer.x, directionToPlayer.y);
    }
    }

    void LookAtPlayer(){
        if (playerTarget != null){
            //Rotates the enemy to look at the player
            Vector3 rotation = playerTarget.transform.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ+90);
    }
    }
}
