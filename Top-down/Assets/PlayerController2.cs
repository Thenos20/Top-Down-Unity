using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed2 = 1f;
    public float collisionOffset2 = 0.05f;
    public ContactFilter2D movementFilter2;
    public SwordAttack swordAttack;

    Vector2 movementInput2;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2;
    Animator animator;
    List<RaycastHit2D> castCollisions2 = new List<RaycastHit2D>();
    bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void FixedUpdate()
    {
        if(canMove){
            if (movementInput2 != Vector2.zero)
            {
                bool success = TryMove(movementInput2);

                if (!success && movementInput2.x > 0)
                {
                    success = TryMove(new Vector2( movementInput2.x, 0));

                    if (!success && movementInput2.y >0)
                    {
                        success = TryMove(new Vector2(0, movementInput2.y));
                    }
                }
                animator.SetBool("isMoving", success);
                
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if(movementInput2.x < 0)
            {
                spriteRenderer.flipX = true;
                
            }
            else if(movementInput2.x > 0)
            {
                spriteRenderer.flipX = false;
                
            }
        }
    }
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Check for potential collisions
            int count = rb2.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter2, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions2, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed2 * Time.fixedDeltaTime + collisionOffset2); // The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                rb2.MovePosition(rb2.position + direction * moveSpeed2 * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput2 = movementValue.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack(){
        LockMovement();
        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        }
        else{
            swordAttack.AttackRight();
        }
        
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }
}