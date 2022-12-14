using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    public HealthBar healthBar;
    private Slider starHealth;
    public static int CurrentHealth = 0;

    private void Start()
    {
        starHealth = GetComponent<Slider>();
    }

    private void Update()
    {
        starHealth.value = CurrentHealth;
        if(CurrentHealth == 0)
        {
          healthBar.Damage(.01f);
        }
    }

}
