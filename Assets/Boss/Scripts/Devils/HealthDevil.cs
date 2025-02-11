using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDevil : MonoBehaviour
{
    public float startHealth = 60;
    float health;
    Roaring roar;

    Transform devilHealth;
    float scaleX;
    // Start is called before the first frame update
    void Start()
    {
        roar = GameObject.Find("FinalBoss").GetComponent<Roaring>();
        health = startHealth;
        devilHealth = transform.GetChild(2).transform;
        scaleX = devilHealth.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 )
        {
            roar.RemoveFromList();
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        devilHealth.transform.localScale = new Vector3(health * 100 / startHealth / 100, 0.1182905f, -0.009039547f);
    }
}
