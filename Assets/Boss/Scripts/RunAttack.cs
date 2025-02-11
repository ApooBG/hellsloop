using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAttack : MonoBehaviour
{
    Animator animator;
    bool activateJumpAttack = false;

    private Transform target;
    public float distance = 7f;
    float distanceToTarget = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        target = GameObject.Find("First Person Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (activateJumpAttack) //activates the animations
        {
            if (animator.GetBool("Run") == false)
                animator.SetBool("Run", true);
            Running();
        }
    }

    void Running()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //calculates the distance between the boss and the player
        if (distanceToTarget < distance) //if in range
        {
            animator.SetBool("Run", false);
            animator.SetBool("JumpAttack", true);
            JumpAttack(); //attack him with the jump attack
            activateJumpAttack = false;
        }
    }

    void JumpAttack()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "JumpAttack") //prevents bugs
        {
            activateJumpAttack = false;
            animator.SetBool("JumpAttack", false);
        }

    }

    public void ActivateJumpAttack() //when this method is called, the special running + jump attack animations are activated.
    {
        activateJumpAttack = true;
    }


}
