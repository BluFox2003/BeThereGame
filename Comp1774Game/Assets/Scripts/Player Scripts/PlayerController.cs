using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horzDirection;
    float vertDirection;
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horzDirection = Input.GetAxis("Horizontal");
        vertDirection = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        // Move the player
        if(!Manager.isPaused){
        playerRB.velocity = new Vector2(horzDirection * moveSpeed, vertDirection * moveSpeed); 
    }
    }
}
