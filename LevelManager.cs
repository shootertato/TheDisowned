using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public float waitRespawn;

    void Awake() {
        instance = this;
    }

    public void RespawnPlayer(){
        StartCoroutine(Respawn());
    }
    
    IEnumerator Respawn(){
        AudioManager.instance.StopSoundEffect(2);
        AudioManager.instance.PlaySoundEffect(0);
        yield return new WaitForSeconds(waitRespawn);
        PlayerHealthController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIcontroller.instance.UpdateHealthDisplay();
        AudioManager.instance.PlaySoundEffect(2);
        AudioManager.instance.StopSoundEffect(0);
        CharacterController.instance.speed=4;
		CharacterController.instance.jumpForce=7;
    }
}
