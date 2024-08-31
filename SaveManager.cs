using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;



[System.Serializable]
public class GameData
{
    public int playerHealth;
    public Vector3 playerPosition;
    public string sceneName; // Numele scenei curente
}
public class SaveManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    private string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    public void SaveGame(int health, Vector3 position, string currentScene)
    {
        GameData data = new GameData();
        data.playerHealth = health;
        data.playerPosition = position;
        data.sceneName = currentScene;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Game Saved");
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found");
            return null;
        }
    }
}
