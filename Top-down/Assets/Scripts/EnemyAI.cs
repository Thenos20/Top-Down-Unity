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

    //ny
    public CapsuleCollider2D capsuleCollider2D;


    

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
        Vector2 posA = playertofind.transform.position;
        Vector2 posB = transform.position;
        //Destination - Origin
        Vector2 dir = (posB - posA).normalized;
        
        if(dir.x > 0) {
                spriteRenderer.flipX = true;
            } else if (dir.x < 0) {
                spriteRenderer.flipX = false;
            }


        bool success2 = CheckCollisions(capsuleCollider2D, dir, 0.005f);

        if (target != null && !success2){
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

    




    private bool CheckCollisions(Collider2D moveCollider, Vector2 direction, float distance){
        
        if (moveCollider != null){
            RaycastHit2D[] hits = new RaycastHit2D[10];
            ContactFilter2D filter = new ContactFilter2D()
            {
            };

            int numHits = moveCollider.Cast(direction, filter, hits, distance);

            for (int i = 0; i < numHits; i++){
                if (!hits[i].collider.isTrigger){
                    return true;
                }
            }
        }
        return false;
    }

    
    

}
