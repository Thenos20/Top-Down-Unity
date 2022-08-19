using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float AIspeed = 1f;
    private Transform target;

    private void Update(){
        if (target != null){
            float step = AIspeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

        else{
            return;
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
