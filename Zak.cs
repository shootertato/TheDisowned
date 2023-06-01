using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Zak : MonoBehaviour {
    public GameObject player;
    void OnDestroy(){
        SceneManager.LoadScene("Zak Muere");
    }
}
