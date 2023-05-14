using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour {
	public static PlayerHealthController instance;
   	public int currentHealth, maxHealth;
 	private Animator animator;

	private void Awake(){
		instance = this;
		animator = GetComponent<Animator>();
	}

	void Start(){
		currentHealth = maxHealth;
	}	

	private void Update() {
		if(currentHealth > 0){
			animator.SetBool("isDead", false);
		}
	}
	
	public void DealDamage(){
		currentHealth--;
		if(currentHealth <= 0){
			animator.SetBool("isDead", true);
			LevelManager.instance.RespawnPlayer();
		}
		UIcontroller.instance.UpdateHealthDisplay();
	}

}