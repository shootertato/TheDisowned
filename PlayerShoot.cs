using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private Transform shootController;
    [SerializeField] private GameObject bullet;
    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
            AudioManager.instance.PlaySoundEffect(3);
        }
    }

    private void Shoot(){
        Instantiate(bullet, shootController.position, shootController.rotation);
    }

}
