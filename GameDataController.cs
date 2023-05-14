using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour {
    public static GameDataController instance;
    public GameObject player;
    public string saveFile;
    public GameData gameData = new GameData();

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C)){
            LoadData();
        }

        if(Input.GetKeyDown(KeyCode.G)){
            SaveData();
        }

    }

    private void Awake() {
        instance = this;
        saveFile = Application.dataPath + "/gameData.json";

        player = GameObject.FindGameObjectWithTag("Player");
        
        LoadData();
    }

    private void LoadData() {
        if(File.Exists(saveFile)){
            string content = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(content);

            player.transform.position = gameData.position;
            player.GetComponent<PlayerHealthController>().currentHealth = gameData.health;
            UIcontroller.instance.UpdateHealthDisplay();
        }
    }

    private void SaveData() {
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<PlayerHealthController>().currentHealth
        };

        string jsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, jsonString);
    }
}
