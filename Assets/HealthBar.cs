using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Fill;
    public float maxHealth;

    public void SetHealth(float health)
    {
        Fill.fillAmount = health/maxHealth;
        Debug.Log(health/maxHealth);
    }
    
    public float GetHealth()
    {
        return Fill.fillAmount * maxHealth;
    }
}
