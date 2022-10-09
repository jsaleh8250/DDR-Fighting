using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    private Slider starHealth;
    public static int CurrentHealth = 100;

    private void Start()
    {
        starHealth = GetComponent<Slider>();
    }

    private void Update()
    {
        starHealth.value = CurrentHealth;
    }

}
