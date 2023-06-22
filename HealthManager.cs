using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Health system made as a singleton
    private static HealthManager instance = null;
    public static HealthManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public float maxHealth = 100.0f;    //Max Player Health
    float _currentHealth;   //Current Player Health
    AudioSource _sound; //Sound of Damage
    Gameover _gameover; //Gameover Instance

    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _currentHealth = maxHealth;
        _gameover = FindObjectOfType<Gameover>();
    }

    // The amount of health to add/subtract from the current health
    public void ChangeHealth(float amount)
    {
        _currentHealth += amount;

        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
        else if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _sound.Play();
            _gameover.Dead();           
        }
    }

    //Returns the amount of health that the player still has
    public float getCurrentHealth()
    {
        return _currentHealth;
    }
}
