using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{   

    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canShoot;
    private float timer;
    public float fireRate;
    private MuzzleFlash muzzleFlash;
    public int ammoCount;
    GameUI gameUI;
    public GameObject audioObject;
    WeaponSelect weaponSelect;

    // Start is called before the first frame update
    void Start()
    {
       muzzleFlash = GameObject.FindGameObjectWithTag("Flash").GetComponent<MuzzleFlash>();
        gameUI = FindObjectOfType<GameUI>();
        weaponSelect = FindObjectOfType<WeaponSelect>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = Manager.ammoCount;
        if (!Manager.isPaused){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ+90);

        if(!canShoot && ammoCount > 0){
            timer += Time.deltaTime;
            if(timer > fireRate){
                canShoot = true;
                timer = 0;
            }
        }
        else if(ammoCount <= 0){
            canShoot = false;
            //add click sound and maybe text to say find more ammo??
        }

        WeaponType();
        AutoFire();
            
        }
        //}
        
    }
    
    void FireWeapon(){
                muzzleFlash.Flash();
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                Manager.ammoCount -= 1;
                //FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Shoot, transform.position, 1f);
                canShoot = false;
                gameUI.UpdateAmmo();
}

    void AutoFire(){
        if(Input.GetMouseButton(0) && canShoot){
                FireWeapon();
    }
    }

    void WeaponType(){
        switch (weaponSelect.currentWeapon)
        {
            case WeaponSelect.WeaponType.Pistol:
                fireRate = 0.5f;
                break;
            case WeaponSelect.WeaponType.Shotgun:
                fireRate = 1f;
                break;
            case WeaponSelect.WeaponType.MachineGun:
                fireRate = 0.1f;
                break;
        }
    }

}
