using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public bool isAttacking;

    [SerializeField] float damage;
    PlayerHealth playerHealth;
    // Start is called before the first frame update

    private void Start()
    {
        playerHealth = GameObject.Find("First Person Controller").GetComponent<PlayerHealth>();
    }

    public void DamagePlayer()
    {
        isAttacking = true;
    }

    public void MakeAttackingFalse()
    {
        isAttacking = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isAttacking)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerHealth.InflictDamage(damage);
                MakeAttackingFalse();
            }
        }
    }
}
