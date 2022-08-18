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

    public float playerhealth = 6;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayerDefeated(){
        animator.SetTrigger("PlayerDefeated");
    }

    public void RemovePlayer() {
        this.gameObject.SetActive(false);
    }


    

    void ifsword(){//sätt in i ontrigger2d och använd för att inte ta dmg
        if(swordattack2.swordCollider.enabled == true){
            return;
        }
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" && this.animator.GetCurrentAnimatorStateInfo(0).IsName("player_attack") == false) {
            Enemy enemy = other.GetComponent<Enemy>();
            // Deal damage to the enemy
            playerhealth -= slimedamage;
            Debug.Log("Trigger");

            
            if(playerhealth <= 0) {
                
                PlayerDefeated();
                Debug.Log("playerdeath");
            }
            
        
        }
    }
}
