using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour {
    public static BossTankController instance;
    [SerializeField] private float life;
    public float moveSpeed;
    public Transform lPoint, rPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public float moveTime, waitTime;
    private float moveCount, waitCount;
    private Animator animator;
    public float chance;
    public GameObject collectible;

    private void Awake(){
		instance = this;
	}
        
    void Start() {
        theRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        lPoint.parent = null;
        rPoint.parent = null;

        movingRight=true;
        moveCount = moveTime;
    }

    void Update() {
        if(moveCount > 0){
            moveCount -= Time.deltaTime;
            if(movingRight){
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = true;

                if(transform.position.x > rPoint.position.x){
                    movingRight = false;
                }
            }else{
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = false;

                if(transform.position.x < lPoint.position.x){
                    movingRight = true;
                }
            }

            if(moveCount <= 0){
                waitCount = Random.Range(waitTime* .75f, waitTime*1.25f);
            }
            animator.SetBool("isMoving", true);
        }else if(waitCount > 0){
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0){
                moveCount = Random.Range(moveTime* .75f, waitTime*1.25f);
            }
            animator.SetBool("isMoving", false);
        }  
    }

    public void TakeDamage(float dmg){
        life -= dmg;
        if (life <= 0){
            float drop = Random.Range(0, 100f);
            if(drop <= chance){
                Instantiate(collectible, theRB.transform.position, theRB.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}