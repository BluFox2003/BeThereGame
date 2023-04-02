using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
           
        
        GiveItem();
        DestroyItem();
        }
    }

    protected virtual void GiveItem() {
        Debug.Log("Item given");
    }

    protected void DestroyItem() {
        Destroy(gameObject);
    }
}
