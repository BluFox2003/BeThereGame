using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] float bulletSpeed = 2f;
    public bool canShoot = false;
    private float timer;
    public float fireRate = 3;
    

    public void Shoot(float xDir, float yDir){
        if(canShoot){
        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        bulletInstance.velocity = new Vector3(xDir, yDir) * bulletSpeed;
        canShoot = false;
        }
    }

    void Update(){
        if(!canShoot){
            timer += Time.deltaTime;
            if(timer > fireRate){
                canShoot = true;
                timer = 0;
            }
        }
    }


}
