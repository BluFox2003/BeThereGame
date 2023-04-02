using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{   
    public static Manager instance;
    public enum DoorKeyColours { Red, Blue, Green };
    public static bool redKey, blueKey, greenKey;
    static GameUI gameUI; 
    public static bool isPaused;
    public static int ammoCount;
    public GameObject audioObject;

     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameUI = FindObjectOfType<GameUI>();
        ammoCount = 20;
        gameUI.UpdateAmmo();
    }

    public static void AddAmmo(int ammoValue)
    {
        ammoCount += ammoValue;
        gameUI.UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void KeyPickup(DoorKeyColours keyColour)
    {
        switch (keyColour)
        {
            case DoorKeyColours.Red:
                redKey = true;
                break;
            case DoorKeyColours.Blue:
                blueKey = true;
                break;
            case DoorKeyColours.Green:
                greenKey = true;
                break;
        }
        gameUI.UpdateKeys(keyColour);
        
    }
}

