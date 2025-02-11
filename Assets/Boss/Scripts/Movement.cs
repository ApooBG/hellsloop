using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    private Transform target;

    public float distance = 5f;
    float distanceToTarget = Mathf.Infinity;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attack;
    [SerializeField] AudioClip walk;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("First Person Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        distanceToTarget = Vector3.Distance(target.position, transform.parent.position); //checks the distance from the boss to the player
        if (distanceToTarget > distance) //if out of range
        {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack")
            {
                if (animator.GetBool("Attack") == true) //disables attacking animation to prevent bugs
                {
                    animator.SetBool("Attack", false);
                }

                if (animator.GetBool("Walking") == false) //walks (its just an animation)
                {
                    animator.SetBool("Walking", true);
                }
                if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Mutant Walking")
                {
                    if (audioSource.clip != walk || !audioSource.isPlaying)
                    {
                        audioSource.clip = walk;
                        audioSource.Play();
                    }
                }
            }
            
        }

        else //if its in range
        {
            if (animator.GetBool("Walking") == true) //disables walking animation to prevent bugs
            {
                animator.SetBool("Walking", false); 
            }

            if (animator.GetBool("Attack") == false) //attacks 
            {
                animator.SetBool("Attack", true);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.clip = attack;
                audioSource.Play();
            }
        }
        
    }
}
