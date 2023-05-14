using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    private Animator animator;
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
}