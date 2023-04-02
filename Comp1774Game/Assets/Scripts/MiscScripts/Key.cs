using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectableItem
{
    GameObject personCollecting;
    public Manager.DoorKeyColours keyColour;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        switch (keyColour)
        {
            case Manager.DoorKeyColours.Red:
                sr.color = Color.red;
                break;
            case Manager.DoorKeyColours.Blue:
                sr.color = Color.blue;
                break;
            case Manager.DoorKeyColours.Green:
                sr.color = Color.green;
                break;
        }
    }


    protected override void GiveItem(){
            Manager.KeyPickup(keyColour);
    }


}
