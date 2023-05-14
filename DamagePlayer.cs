using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerHealthController.instance.DealDamage();
        }
    }  
}
