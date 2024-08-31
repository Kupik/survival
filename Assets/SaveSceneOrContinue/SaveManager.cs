using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;



[System.Serializable]
public class GameData
{
    public int HP;
    public Vector3 Player;
    public string SceneName;
}

public class SaveManager : MonoBehaviour
{
    private string saveFile; // file

    private void Start()
    {
        saveFile = Path.Combine(Application.persistentDataPath, "savefile.json");
        Debug.Log("Save file path: " + saveFile);
    }

    public void SaveGame(int health, Vector3 position, string currentScene)
    {
        GameData data = new GameData();
        data.HP = health;
        data.Player = position;
        data.SceneName = currentScene;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFile, json);
        Debug.Log(json);
        Debug.Log("Game saved successfully");
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }



}
