using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] LayerMask enemyLayer, wallLayer;
    bool shotEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    //Update is called once per frame
    void Update()
    {
        ShotEnemy();
        ShotWall();
    }
    bool CheckCollison(LayerMask l){
        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, l);
        if (col){
            if(l == enemyLayer){
                col.gameObject.GetComponent<EnemyHealth>().RecieveHit(1);
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
    

    void ShotWall(){
        if(CheckCollison(wallLayer)){
            Destroy(gameObject);
        }
    }
    void ShotEnemy(){
        shotEnemy = CheckCollison(enemyLayer);
    }
}

