using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour {
    public static GameDataController instance;
    public GameObject player;
    public string saveFile;
    public GameData gameData = new GameData();

    private void Awake() {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player");     
    }

    public void LoadData1() {
        saveFile = Application.dataPath + "/gameData1.json";
        if(File.Exists(saveFile)){
            string content = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(content);

            player.transform.position = gameData.position;
            player.GetComponent<PlayerHealthController>().currentHealth = gameData.health;
            UIcontroller.instance.UpdateHealthDisplay();
        }
    }

    public void LoadData2() {
        saveFile = Application.dataPath + "/gameData2.json";
        if(File.Exists(saveFile)){
            string content = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(content);

            player.transform.position = gameData.position;
            player.GetComponent<PlayerHealthController>().currentHealth = gameData.health;
            UIcontroller.instance.UpdateHealthDisplay();
        }
    }

    public void LoadData3() {
        saveFile = Application.dataPath + "/gameData3.json";
        if(File.Exists(saveFile)){
            string content = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(content);

            player.transform.position = gameData.position;
            player.GetComponent<PlayerHealthController>().currentHealth = gameData.health;
            UIcontroller.instance.UpdateHealthDisplay();
        }
    }

    public void SaveData1() {
        saveFile = Application.dataPath + "/gameData1.json";
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<PlayerHealthController>().currentHealth
        };

        string jsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, jsonString);
    }

    public void SaveData2() {
        saveFile = Application.dataPath + "/gameData2.json";
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<PlayerHealthController>().currentHealth
        };

        string jsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, jsonString);
    }

    public void SaveData3() {
        saveFile = Application.dataPath + "/gameData3.json";
        GameData newData = new GameData(){
            position = player.transform.position,
            health = player.GetComponent<PlayerHealthController>().currentHealth
        };

        string jsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, jsonString);
    }
}
