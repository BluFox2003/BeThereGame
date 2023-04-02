using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int initialHealth = 3;
    private int hitPointsLeft;
    private SpriteRenderer sr;
    public GameObject blood;
    public Transform bloodTransform;
    private Color originalColour;
    [SerializeField] Color deathColour = Color.red;
    private CamShake shake;
    public GameObject audioObject;
    public GameObject Meds, Ammo;
    int randomDrop;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColour = sr.color;
        hitPointsLeft = initialHealth;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }
    public void RecieveHit(int damage){
        hitPointsLeft -= damage;
        ChangeColour();
        if(hitPointsLeft <= 0){
            //FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.EnemyDeath, transform.position, 1f);
            Destroy(gameObject);
            shake.Shake();
            Instantiate(blood, bloodTransform.position, Quaternion.identity);
            //drop random item
            randomDrop = Random.Range(0, 3);
            switch(randomDrop){
                case 0:
                    Instantiate(Meds, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Ammo, transform.position, Quaternion.identity);
                    break;
                case 2:
                    break;
            }
        }
    
    }

    void ChangeColour(){
        float percentageOfDamageTaken = 1f -((float)hitPointsLeft/(float)initialHealth);
        Color newHealthColour = Color.Lerp(originalColour, deathColour, percentageOfDamageTaken);
        sr.color = newHealthColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
