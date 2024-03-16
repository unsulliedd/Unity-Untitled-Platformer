using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{private float health;
    private float lerpTimer;
    public float maxHealth=100f;
    public float chipSpeed=2f;
    public Image FrontHealth;
    public Image BackHealth;
    void Start()
    {
        health=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health=Mathf.Clamp(health,0,maxHealth);
        UpdateHealthUI();
        if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(Random.Range(5,10));
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            RestoreHealth(Random.Range(5,10));
        }
    }
    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF=FrontHealth.fillAmount;
        float fillB=BackHealth.fillAmount;
        float hFraction=health/maxHealth;
        if(fillB >hFraction)
        {
            FrontHealth.fillAmount=hFraction;
            BackHealth.color=Color.red;
            lerpTimer+=Time.deltaTime;
            float percentComplete=lerpTimer / chipSpeed;
            percentComplete=percentComplete*percentComplete;
            BackHealth.fillAmount=Mathf.Lerp(fillB,hFraction,percentComplete);
        }

        if(fillF<hFraction)
        {
            BackHealth.color=Color.green;
            BackHealth.fillAmount=hFraction;
            lerpTimer+=Time.deltaTime;
            float percentComplete=lerpTimer /chipSpeed;
            percentComplete=percentComplete*percentComplete;
            FrontHealth.fillAmount=Mathf.Lerp(fillF,BackHealth.fillAmount,percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -=damage;
        lerpTimer=0f;
    }

    public void RestoreHealth(float healAmont)
    {
        health += healAmont;
        lerpTimer=0f;
    }
}
