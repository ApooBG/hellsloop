using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health; //current health
    [SerializeField] float startingHealth; 
    [SerializeField] GameObject damageText; //the text itself
    [SerializeField] Animator animator; //the animator of the text

    Animator bossAnimator;
    ShowDamage showDamage; //the damage script
    Image healthBar; //the health UX

    Transform parentTransform = null; 
    Roaring roaring; //needed to spawn enemies

    bool canSpawn = false;
    bool canHurt = false;

    int healthPercentage = 100; //start with healthPercentage
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        parentTransform = GameObject.Find("Boss").transform;
        showDamage = GameObject.Find("Damaged").GetComponent<ShowDamage>();
        healthBar = GameObject.Find("HealthBarInner").GetComponent<Image>();
        roaring = GameObject.Find("FinalBoss").GetComponent<Roaring>();
        bossAnimator = GameObject.Find("FinalBoss").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        showDamage.UpdateState();
        InnerBar();
        CheckHealth();
    }

    void CheckHealth()
    {
        healthPercentage = Convert.ToInt32(health * 100 / startingHealth); //updates the percentage of the health into the smaller and closest int number

        if (healthPercentage % 5 == 0 && canHurt == true && healthPercentage % 25 != 0) //everytime the boss loses 5% he gets hurt (animation) excluding the 25%
        {
            canHurt = false; //makes sure that the animation doesn't repeat before the next time it has to be called
            bossAnimator.SetBool("Hurt", true);

            if (bossAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Hurt")
            {
                bossAnimator.SetBool("Hurt", false);
            }
        }
        
        else if (healthPercentage % 5 != 0) //use it to call the function once 5% of his health goes to missing again
        {
            canHurt = true;
            bossAnimator.SetBool("Hurt", false);
        }

        if (healthPercentage % 25 == 0  && canSpawn == true) //everytime the boss loses 25% of his health, he roars and spawns enemies
        {
            canSpawn = false;
            roaring.Roar();
        }

        else if (healthPercentage % 25 != 0) //resets it and prevents bugs
        {
            if (canSpawn == false)
                canSpawn = true;
        }

        if (healthPercentage == 10) //when he goes down to 10% of his health he falls down
        {
            bossAnimator.SetBool("FallingDown", true);
        }

        if (bossAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "FallingDown") //prevents bugs
        {
            bossAnimator.SetBool("FallingDown", false);
        }

        if (healthPercentage == 5) //if he is down to 5%, the cutscene should show up.
        {
            Debug.Log("Kill or get killed");
        }
    }

    public void TakeDamage(float damage) //when the player shoots, he takes damage and reduces the health.
    {
        health -= damage;
        showDamage.TakeDamage(damage, parentTransform);

    }

    void InnerBar() //UX healthbar update
    {
        healthBar.fillAmount = health / startingHealth;
    }

    public void Heal(float heal) //maybe healing?
    {
        health += heal;
    }
}
