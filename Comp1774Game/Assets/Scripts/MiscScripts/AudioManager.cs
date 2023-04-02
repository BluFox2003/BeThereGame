using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum SoundFXCat {Shoot, PickupKey, PickupAmmo, UnlockDoor, Death, EnemyDeath, Hurt, EmptyAmmo, PickupMeds}
    public GameObject audioObject;
    public AudioClip[] shoot;
    public AudioClip[] pickupKey;
    public AudioClip[] pickupAmmo;
    public AudioClip[] unlockDoor;
    public AudioClip[] death;
    public AudioClip[] enemyDeath;
    public AudioClip[] hurt;
    public AudioClip[] emptyAmmo;
    public AudioClip[] pickupMeds;

public void AudioTrigger(SoundFXCat audioType, Vector3 audioPosition, float volume){
    GameObject newAudio = GameObject.Instantiate(audioObject, audioPosition, Quaternion.identity);
    ControlAudio ca = newAudio.GetComponent<ControlAudio>();
    switch(audioType){
        case (SoundFXCat.Shoot):
            ca.myClip = shoot[Random.Range(0, shoot.Length)];
            break;
        case (SoundFXCat.PickupKey):
            ca.myClip = pickupKey[Random.Range(0, pickupKey.Length)];
            break;
        case (SoundFXCat.PickupAmmo):
            ca.myClip = pickupAmmo[Random.Range(0, pickupAmmo.Length)];
            break;
        case (SoundFXCat.UnlockDoor):
            ca.myClip = unlockDoor[Random.Range(0, unlockDoor.Length)];
            break;
        case (SoundFXCat.Death):
            ca.myClip = death[Random.Range(0, death.Length)];
            break;
        case (SoundFXCat.EnemyDeath):
            ca.myClip = enemyDeath[Random.Range(0, enemyDeath.Length)];
            break;
        case (SoundFXCat.Hurt):
            ca.myClip = hurt[Random.Range(0, hurt.Length)];
            break;
        case (SoundFXCat.EmptyAmmo):
            ca.myClip = emptyAmmo[Random.Range(0, emptyAmmo.Length)];
            break;
        case (SoundFXCat.PickupMeds):
            ca.myClip = pickupMeds[Random.Range(0, pickupMeds.Length)];
            break;
    }
    ca.volume = volume;
    ca.StartAudio();
}
}
