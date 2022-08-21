using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHitbox : MonoBehaviour
{
    public Collider2D swordCollider;
    public float swordDamage = 1f;
    void Start(){
        if (swordCollider == null){
            Debug.Log("Sword Collider not set");
        }
    }

    

    void OnCollisionEnter2D(Collision2D col){
        col.collider.SendMessage("OnHit", swordDamage);
    }
}
