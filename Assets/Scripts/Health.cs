using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    [SerializeField]
    int currentHealth;

    public void Start()
    {
        Time.timeScale = 1;
    }
    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        SceneManager.LoadScene(4);
    }
}