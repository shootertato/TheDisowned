using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour {
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
     private  GameObject player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        float dist = Vector2.Distance(transform.position, player.transform.position);

        if(dist < 20){
            timer += Time.deltaTime;
            if (timer > 2) {
                if(PlayerHealthController.instance.currentHealth != 0){
                    timer = 0; 
                    Shoot();
                }
                
            }
        }
    }

    void Shoot(){
        AudioManager.instance.PlaySoundEffect(4);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
