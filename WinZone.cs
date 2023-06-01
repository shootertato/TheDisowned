using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinZone : MonoBehaviour {
    public GameObject end;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene("Zak No Muere");
        }
    }
}
