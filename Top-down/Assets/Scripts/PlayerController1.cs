using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController1 : MonoBehaviour
{

    bool Ismoving{
        set{
            ismoving = value;
            animator.SetBool("ismoving", ismoving);
        }
    }

    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;

    Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 moveInput = Vector2.zero;

    bool ismoving = false;
    bool canmove = true;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if(canmove == true && moveInput != Vector2.zero){
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);

            if (moveInput.x > 0){
                spriteRenderer.flipX = false;
            } else if (moveInput.x < 0){
                spriteRenderer.flipX = true;
            }
            Ismoving = true;
            
        } else {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            Ismoving = false;
        }
        
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordattack");
    }

    void Lockmovement(){
        canmove = false;
    }

    void Unlockmovement(){
        canmove = true;
    }
}
