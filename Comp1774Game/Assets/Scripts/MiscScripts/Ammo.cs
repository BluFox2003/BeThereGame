using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : CollectableItem
{
        public int ammoValue = 25;
        //public GameObject audioObject;
        protected override void GiveItem(){
            Manager.AddAmmo(ammoValue);
        }
        
    
}
