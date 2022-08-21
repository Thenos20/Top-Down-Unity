using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{


    Animator animator;

    public float Health{
        set{
            float OldHp = _health;
            _health = value;
            if (OldHp > _health){
                //Debug.Log(dmg);
                animator.SetTrigger("hit");
                Debug.Log(_health);
            }
            if (_health <= 0){
                animator.SetTrigger("death");
            }
        }
        get{
            return _health;
        }
    }

    public void Start(){
        animator = GetComponent<Animator>();
    }

    public float _health = 3;
    
    void OnHit(float damage){
        Debug.Log("slime has been hit" + damage);
        Health -= damage;
        
    }

}
