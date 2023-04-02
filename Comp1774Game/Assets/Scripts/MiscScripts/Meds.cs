using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meds : CollectableItem
{
    public int healthValue = 2;
    //public GameObject audioObject;
    protected override void GiveItem(){
       
            PlayerHealth.HealDamage(healthValue);
    }
}
