using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    //[SerializeField] public static bool canOpen;
    GameObject personOpening;
    public Manager.DoorKeyColours keyColour;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        personOpening = collision.gameObject;
        if (personOpening.tag == "Player") {
         switch (keyColour)
            {
                case Manager.DoorKeyColours.Red:
                    if (Manager.redKey)
                    {
                        Destroy(gameObject);
                    }
                    break;
                case Manager.DoorKeyColours.Blue:
                    if (Manager.blueKey)
                    {
                        Destroy(gameObject);
                    }
                    break;
                case Manager.DoorKeyColours.Green:
                    if (Manager.greenKey)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
        
    }

}
