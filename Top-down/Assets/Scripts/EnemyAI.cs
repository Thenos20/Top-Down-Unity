using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float AIspeed = 1f;
    private Transform target;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void EnemyMove(){
        animator.SetTrigger("EnemyMove");
    }

    public void EnemyStopMove(){
        animator.SetTrigger("EnemyStopMove");
    }

    private void Update(){
        if (target != null){
            float step = AIspeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            EnemyMove();
        }

        else if (target == null){

            EnemyStopMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            target = other.transform;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            target = null;
        }
    }

}
