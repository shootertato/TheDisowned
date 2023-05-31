using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
     private  GameObject player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        float dist = Vector2.Distance(transform.position, player.transform.position);

        if(dist < 10){
            timer += Time.deltaTime;
            if (timer > 1.5) {
                if(PlayerHealthController.instance.currentHealth != 0){
                    timer = 0; 
                    Shoot();
                }
                
            }
        }
    }

    void Shoot(){
        AudioManager.instance.PlaySoundEffect(3);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
