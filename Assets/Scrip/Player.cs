using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int HP = 100;
    public Slider slider;

    private void Awake()
    {
        Instance = this;
    }

    public void HealthHero(int value)
    {
        HP += value;
        slider.value = HP;
     

    }
   
}
