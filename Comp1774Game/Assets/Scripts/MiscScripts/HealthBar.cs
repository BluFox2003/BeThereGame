using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    float health;
    float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = PlayerHealth.health;
        maxHealth = PlayerHealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = PlayerHealth.health / PlayerHealth.maxHealth;
    }
}
