using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHitbox : MonoBehaviour
{
    public Collider2D swordCollider;
    public float swordDamage = 1f;
    //ny
    public Vector3 faceRight = new Vector3(0.11f, 0, 0);
    public Vector3 faceLeft = new Vector3(-0.11f, 0, 0);

    void Start(){
        if (swordCollider == null){
            Debug.Log("Sword Collider not set");
        }
    }

    
    
    void OnCollisionEnter2D(Collision2D col){
        col.collider.SendMessage("OnHit", swordDamage);
    }
    
    //ny
    void IsFacingRight(bool isFacingRight){
        if (isFacingRight){
            gameObject.transform.localPosition = faceRight;
        }
        else{
            gameObject.transform.localPosition = faceLeft;
        }
    }
}
