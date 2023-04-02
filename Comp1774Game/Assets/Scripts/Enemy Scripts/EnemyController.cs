using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float horzDirection;
    float vertDirection;
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        // Move the enemy
        enemyRB.velocity = new Vector2(horzDirection * moveSpeed, vertDirection * moveSpeed); 
    }

    public void ControlNPC(float hInput, float vInput){
        horzDirection = hInput;
        vertDirection = vInput;
    }
}
