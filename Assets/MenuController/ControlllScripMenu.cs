using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlllScripMenu : MonoBehaviour
{
    public Button ButtonActive; // Butonul de activare
    public Button button1; // Primul buton care trebuie să apară
    public Button button2; // Al doilea buton care trebuie să apară

    public void Start()
    {
        
    }

    public void ActiveOrNoActive()
    {
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }

}
