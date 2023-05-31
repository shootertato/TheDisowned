using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public static CharacterController instance;
    public float speed, jumpForce, movementInput;
    public LayerMask floorLayer;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider; 
    private bool orientation = true;
    private Animator animator;

    private void Awake(){
		instance = this;
	}

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        Movement();
        Jump();
    }

    bool TouchingFloor(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, floorLayer);
        return raycastHit.collider != null;
    }

    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(TouchingFloor()){
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("isJumping", true);
            }
        }else{
            animator.SetBool("isJumping", false);
        }
    }

    void Movement() {
        movementInput = Input.GetAxis("Horizontal");
        if(movementInput != 0f){
            animator.SetBool("isMoving", true);
        }else{
            animator.SetBool("isMoving", false);
        }
        rigidBody.velocity = new Vector2(movementInput * speed, rigidBody.velocity.y);
        Orientation(movementInput);
    }

    void Orientation(float movementInput) {
        if ((orientation == true && movementInput < 0) || (orientation == false && movementInput > 0)) {
            orientation = !orientation;
            /* transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); */
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag==("Platform")){
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag!=("Platform")){
            transform.parent = null;
        }
    }
}
