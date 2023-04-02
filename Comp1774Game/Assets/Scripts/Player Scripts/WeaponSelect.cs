using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public enum WeaponType
    {
        Pistol,
        Shotgun,
        MachineGun,
    }
    public WeaponType currentWeapon;
    public bool hasShotgun;
    public bool hasMachineGun;


    void Start()
    {
        ChangeWeapon(WeaponType.Pistol);

    }

    public void ChangeWeapon(WeaponType newWeapon)
    {
        currentWeapon = newWeapon;
        switch (currentWeapon)
        {
            case WeaponType.Pistol:
                Debug.Log("Pistol");
                break;
            case WeaponType.Shotgun:
                Debug.Log("Shotgun");
                break;
            case WeaponType.MachineGun:
                Debug.Log("Machine Gun");
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(WeaponType.Pistol);
        }
        if (hasShotgun){
            if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ChangeWeapon(WeaponType.Shotgun);
                }
        }
        if (hasMachineGun){
            if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeWeapon(WeaponType.MachineGun);
                }
        }
    }


    

}
