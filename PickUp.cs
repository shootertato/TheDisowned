using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public bool isKit;
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isCollected) {
            if (isKit){
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth){
                    PlayerHealthController.instance.Heal();
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
