using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool canBeHit;
    [SerializeField] float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InflictDamage(float damage)
    {
        health -= damage;
    }
}
