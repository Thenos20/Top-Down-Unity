using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    bool isAlive = true;
    Animator animator;

    public float Health{
        set{
            
            //OldHp > _health
            if (value < _health){
                //Debug.Log(dmg);
                animator.SetTrigger("hit");
                //Debug.Log(_health);
            }

            
            _health = value;
            
            if (_health <= 0){
                animator.SetBool("isAlive", false);
            }
        }
        get{
            return _health;
            
        }
    }

    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    public float _health = 3;
    
    void OnHit(float damage){
        Debug.Log("slime has been hit" + damage);
        Health -= damage;
        
    }

}
