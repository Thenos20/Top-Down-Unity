using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    
    
    Vector2 rightAttackOffset;
    Collider2D swordCollider;

    private void Start(){
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    

    public void AttackRight() {
        print("Attack Right");
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft(){
        print("Attack Left");
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x *-1, rightAttackOffset.y);
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    
}
