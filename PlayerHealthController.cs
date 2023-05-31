using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerHealthController : MonoBehaviour {
	public static PlayerHealthController instance;
   	public int currentHealth, maxHealth;
 	private Animator animator;

	private void Awake(){
		instance = this;
		animator = GetComponent<Animator>();
	}

	void Start(){
		if(File.Exists(GameDataController.instance.saveFile)){
			currentHealth = GameDataController.instance.gameData.health;
		}else{
			currentHealth = maxHealth;
		}
	}	

	private void Update() {
		if(currentHealth > 0){
			animator.SetBool("isDead", false);
		}
	}
	
	public void DealDamage(){
		currentHealth--;
		if(currentHealth <= 0){
			CharacterController.instance.speed=0;
			CharacterController.instance.jumpForce=0;
			animator.SetBool("isDead", true);
			LevelManager.instance.RespawnPlayer();
		}
		UIcontroller.instance.UpdateHealthDisplay();
	}

	public void Heal(){
		currentHealth++;
		if(currentHealth > maxHealth){
			currentHealth = maxHealth;
		}
		UIcontroller.instance.UpdateHealthDisplay();
	}

}