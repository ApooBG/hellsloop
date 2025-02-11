using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageUI;
    bool hasToBeShown = false;

    private void Start()
    {
       // damageUI = GameObject.FindWithTag("DamageUI").GetComponent<TextMeshProUGUI>();
    }
    public void UpdateState()
    {
        if (!hasToBeShown) //if the text has to be invisible, deactivate it.
            gameObject.SetActive(false); 
    }


    public void TakeDamage(float damage, Transform parentTransfrom)
    {
        hasToBeShown = true; //makes the text visable
        gameObject.SetActive(true); //sets it active.
        TMP_Text text = gameObject.GetComponent<TMP_Text>(); //get's the gameObject as a textObject
        text.text = damage.ToString(); //changes the text damage
        if (Convert.ToInt32(damage) > 25 && Convert.ToInt32(damage) <= 55) //if its between 25 and 56 make it orange
        {
            text.color = new Color(0.8f, 0.5f, 0.2f, 1f);
        }

        if (damage > 55f) //if its bigger than 55 make it red
        {
            text.color = new Color(0.95f, 0.15f, 0.07f, 1f);
        }

        else if (damage <= 25) //if its below 25 or even its yellow
        {
            text.color = new Color(255f, 240f, 0f, 1f);
        }



        GameObject duplicate = Instantiate(gameObject, transform.position, transform.rotation, parentTransfrom); //creates the same gameObject as a duplicate
        duplicate.GetComponent<Animator>().SetTrigger("Damage"); //activates animation
        Invoke("UpdateStateToFalse", 0.1F); //after 0.1F it gets disabled.
    }

    void UpdateStateToFalse()
    {
        hasToBeShown = false;
    }
}

