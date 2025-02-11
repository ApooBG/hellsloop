using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDevil : MonoBehaviour
{
    public float distance = 3f; //attack range
    float distanceToTarget = Mathf.Infinity;
    Transform target; //player
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("First Person Controller").transform;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position); //checks the distance from the object to the player
        if (distance >= distanceToTarget)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Running", false);
        }

        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Running", true);
        }
    }
}
