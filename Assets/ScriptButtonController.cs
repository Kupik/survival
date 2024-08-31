using SlimUI.ModernMenu;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptButtonController : MonoBehaviour
{

    private Animator CameraObject;

    // campaign button sub menu
    public GameObject Nou;
    public GameObject Yes;

    public GameObject exitMenu;
    void Start()
    {
        CameraObject = transform.GetComponent<Animator>();
          exitMenu.SetActive(true);

    }

    public void PlayHover()
    {
   }

    public void PlayCampaign()
    {
        exitMenu.SetActive(false);
    }
    public void ReturnMenu()
    {

        Nou.SetActive(false);
        Yes.SetActive(false);
    }

    // Are You Sure - Quit Panel Pop Up
    public void AreYouSure()
    {

        Nou.SetActive(true);
        Yes.SetActive(true);
    }

    public void AreYouSureMobile()
    {
        exitMenu.SetActive(true);

       
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
    }

    // Load Bar synching animation

}
    

