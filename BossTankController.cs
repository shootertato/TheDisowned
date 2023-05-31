using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour {
    public static BossTankController instance;
    public enum bossStates{shooting, hurt, moving};
    public bossStates currentStates;
    public Transform boss;
    public Animator anim;
    [Header("Movement")]
    public float moveSpeed;
    public Transform lPoint, rPoint;
    private bool moveRight;
    [Header("Shooting")]
    public GameObject bullet;
    public Transform shootController;
    public float timeToShoot;
    private float shootCounter;
    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitbox;
    [SerializeField] private float life;


    private void Start() {
        currentStates = bossStates.shooting;
       
    }

    private void Update() {
        switch(currentStates){
            case bossStates.shooting:
                shootCounter -= Time.deltaTime;
                if(shootCounter <= 0){
                    shootCounter = timeToShoot;
                    var newBullet = Instantiate(bullet, shootController.position, shootController.rotation);
                    newBullet.transform.localScale = boss.localScale;
                    AudioManager.instance.PlaySoundEffect(4);
                }
            break;

            case bossStates.hurt:
            if (hurtCounter > 0) {
                hurtCounter -= Time.deltaTime;
                Hit();
                if(hurtCounter <= 0){
                    currentStates = bossStates.moving;
                }
            }
            break;

            case bossStates.moving:
                if(moveRight){
                    boss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if(boss.position.x > rPoint.position.x){
                        boss.localScale = new Vector3(1f, 1f, 1f);
                        moveRight = false;
                        EndMove();
                    }else{
                        boss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                        boss.localScale = new Vector3(-1f, 1f, 1f);
                        if(boss.position.x < rPoint.position.x){
                            moveRight = true;
                            EndMove();
                        }
                    }
                }
            break;

        }
    }

    public void Hit(){
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;
        anim.SetTrigger("Hit");
        life--;
        if (life <= 0){
            Destroy(gameObject);
        }
    }

    private void EndMove(){
        currentStates = bossStates.shooting;
        shootCounter = timeToShoot;
        anim.SetBool("StopMoving", true);
        hitbox.SetActive(true); 
    }

}
