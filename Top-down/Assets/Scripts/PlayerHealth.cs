using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    public Collider2D playercollider;
    public float slimedamage = 3;

    public SwordAttack swordattack2;

    public float Player_Health {
        set {
            playerhealth = value;

            if(playerhealth <= 0) {
                Destroy(gameObject);
                PlayerDefeated();
                Debug.Log("playerdeath");
            }
        }
        get {
            return playerhealth;
        }
    }

    public float playerhealth = 1;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayerDefeated(){
        animator.SetTrigger("PlayerDefeated");
    }

    public void RemovePlayer() {
        Destroy(gameObject);
    }


    

    void ifsword(){
        if(swordattack2.swordCollider.enabled == true){
            return;
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            // Deal damage to the enemy
            playerhealth -= slimedamage;
            Debug.Log("Trigger");

            
            if(playerhealth <= 0) {
                this.gameObject.SetActive(false);
                PlayerDefeated();
                Debug.Log("playerdeath");
            }
            
        
        }
    }
}