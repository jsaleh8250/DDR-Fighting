using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    void Start()
    {
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth);

    }

    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage)>= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
        }
        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
