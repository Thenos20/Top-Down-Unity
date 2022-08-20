using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float AIspeed = 1f;
    private Transform target;
    Animator animator;
    public GameObject playertofind;

    SpriteRenderer spriteRenderer;


    private void Start() {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void EnemyMove(){
        animator.SetTrigger("EnemyMove");
    }

    public void EnemyStopMove(){
        animator.SetTrigger("EnemyStopMove");
    }

    private void Update(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Get direction from A to B
        Vector3 posA = playertofind.transform.position;
        Vector3 posB = transform.position;
        //Destination - Origin
        Vector3 dir = (posB - posA).normalized;
        
        if(dir.x > 0) {
                spriteRenderer.flipX = true;
            } else if (dir.x < 0) {
                spriteRenderer.flipX = false;
            }




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
