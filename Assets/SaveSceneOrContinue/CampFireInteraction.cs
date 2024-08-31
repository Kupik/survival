using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireInteraction : MonoBehaviour
{
    // button

    public GameObject buttonMenu; // Asignează aici butonul din inspector
    public GameObject menu; // Asignează aici meniul din inspector
    public float interactionDistance = 5f; // Distanța la care apare butonul

    private Transform playerTransform;
    private bool isNearCampfire = false;

    private void Start()
    {
        playerTransform = Camera.main.transform; // Sau referința la jucător, în funcție de setup
        buttonMenu.SetActive(false); // Ascunde butonul la început
        menu.SetActive(false); // Ascunde meniul la început
    }

    private void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance <= interactionDistance)
        {
            buttonMenu.SetActive(true); // Afișează butonul dacă ești în raza de acțiune
            isNearCampfire = true;
        }
        else
        {
            buttonMenu.SetActive(false); // Ascunde butonul dacă nu ești în raza de acțiune
            isNearCampfire = false;
        }

        if (isNearCampfire && Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf); // Comută între activ și inactiv
        buttonMenu.SetActive(false); // Ascunde butonul după apăsarea tastei
    }

}
