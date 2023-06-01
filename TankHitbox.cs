using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHitbox : MonoBehaviour {
    public BossTankController boss;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag==("Player")){
            PlayerHealthController.instance.DealDamage();
        }
        
        if(other.tag==("Bullet")){
            gameObject.SetActive(false);
        }
    }
}
