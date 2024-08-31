using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DamageDeathScript : MonoBehaviour

{
    // Save Scene info player
    public SaveManager saveManager;

    
    
    
    
    
    
    public static DamageDeathScript Instance;
    public int HP = 100;
    public Animator animator;
    public Slider slider;

    private const int Regen_Start = 30;
    private const int Regen_Limit = 60;
    private const int HP_Regen_Rate = 2;
    private const float Time_To_Regen = 15f;

    private float timeSinceLastDamage = 0f; // Timpul scurs de la ultima primire de daune
    private bool isRegenerating = false;    // Indicator pentru regenerare


    private void Awake()
    {
        Instance = this;
    }

    public void HealthHero(int value)
    {
        HP += value;
        slider.value = HP;


    }


    public void Start()
    {       animator = GetComponent<Animator>();}

   
    void Update()
    {
        slider.value = HP;

        timeSinceLastDamage += Time.deltaTime;

        // Începe regenerarea dacă HP-ul este sub 30, nu este deja în regenerare și timpul scurs depășește 15 secunde
        if (HP < Regen_Start && !isRegenerating && timeSinceLastDamage >= Time_To_Regen)
        {
            StartCoroutine(Regeneration());
        }


        if(Input.GetKeyDown(KeyCode.O))
        {
            SaveGame();
        }

    }


    IEnumerator Regeneration()
    {
        isRegenerating = true; // Marchează că regenerarea este activă

        while (HP < Regen_Limit)
        {
            HP = Mathf.Min(HP + HP_Regen_Rate, Regen_Limit);
            yield return new WaitForSeconds(1f); // Regenerare HP la fiecare secundă
        }

        isRegenerating = false; // Marchează că regenerarea s-a oprit
    }
    public void UpdateHealthUI()
    {
        if (slider != null)
        {
            slider.value = HP;
        }
    }
       public void TakeDamage(int damageAmount)
    {
        if (HP > 0)
        {
            HP -= damageAmount;
            HP = Mathf.Clamp(HP, 0, (int)slider.maxValue);

            if (HP <= 0)
            {
                HP = 0;
                animator.SetTrigger("death");
                GetComponent<Collider>().enabled = false;
                slider.gameObject.SetActive(false);
            }
            else
            {
                animator.SetTrigger("damage");
            }
            UpdateHealthUI();


        }
    }


    public void PrimesteDaune(int damage)
    {
        HP -= damage;
        timeSinceLastDamage = 0f; // Resetează timpul scurs de la ultima primire de daune
    }





    void SaveGame()
    {
        Vector3 player = transform.position;
        string currentScene = SceneManager.GetActiveScene().name;
        saveManager.SaveGame(HP, player, currentScene);
    }

}
