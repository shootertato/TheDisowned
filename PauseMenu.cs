using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject menuPause;
    private void Start() {
        Time.timeScale = 0f;
    }

    private void Update() {
        Pause();
    }
    public void Pause() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0f;
            menuPause.SetActive(true);
        }
    }

    public void Resume(){
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
}
