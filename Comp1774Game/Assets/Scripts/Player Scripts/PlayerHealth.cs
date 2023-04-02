using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public static float health;
    public static float maxHealth = 10;
    static GameUI gameUI;
    
    private void Awake(){
        gameUI = FindObjectOfType<GameUI>();
        health = 10;
    }

    public void DealDamage(int damageAmount){
        health -= damageAmount;
        gameUI.HitEffect();
        if(health <= 0){
            gameUI.CheckGameState(GameUI.GameState.GameOver);
            Destroy(gameObject);
        }
    }

    public static void HealDamage(int healAmount){
        health += healAmount;
        if(health > maxHealth){
            health = maxHealth;
        }
    }
}
