using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public SaveManager saveManager;
    private GameData loadedData;




    public GameObject loadingMenu;
    public Slider loadingBar;
  
    public TMP_Text loadPromptText;
    public KeyCode userPromptKey;
    public bool waitForInput = true;

    public void StartNewGame()
    {
        StartCoroutine(LoadAsynchronously("Word")); // Înlocuiește cu numele scenei tale
        Debug.Log("New game started");
    }

    public void ContinueGame()
    {
        GameData data = saveManager.LoadGame();
        if (data != null)
        {
            loadedData = data;
            StartCoroutine(LoadAsynchronously(data.SceneName));
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (loadedData != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = loadedData.Player;
                DamageDeathScript playerScript = player.GetComponent<DamageDeathScript>();
                if (playerScript != null)
                {
                    playerScript.HP = loadedData.HP;
                    playerScript.UpdateHealthUI();
                }
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameWithLoading());
    }

    private IEnumerator ExitGameWithLoading()
    {
     
        loadingMenu.SetActive(true);

        yield return new WaitForSeconds(2); // Așteaptă 2 secunde înainte de a ieși

        Application.Quit();
        Debug.Log("Game exited");
    }



    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

      
        loadingMenu.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;

            if (operation.progress >= 0.9f && waitForInput)
            {
                loadPromptText.text = "Press " + userPromptKey.ToString().ToUpper() + " to continue";
                loadingBar.value = 1;

                if (Input.GetKeyDown(userPromptKey))
                {
                    operation.allowSceneActivation = true;
                }
            }
            else if (operation.progress >= 0.9f && !waitForInput)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    //Loading
}
