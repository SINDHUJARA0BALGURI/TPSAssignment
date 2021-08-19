using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    
    public int startHealth = 10;
    [SerializeField]
    public int currentHealth;
    public static Health instance;

    private void Awake()
    {
        instance = this;
        

    }
    public void Start()
    {
       
        Time.timeScale = 1;
        currentHealth = startHealth;
        UIController.instance.healthSlider.maxValue = startHealth;

    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health" + currentHealth;
    }
    private void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        SceneManager.LoadScene(4);
    }
}