using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
    public Button playButton;
    void Start() {
        playButton.onClick.AddListener(LoadGameScene);
    }
    void LoadGameScene() {
        SceneManager.LoadScene("The Disowned");
    }
}
