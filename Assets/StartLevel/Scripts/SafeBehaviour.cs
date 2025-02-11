using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBehaviour : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] GameObject player;
    [SerializeField] float distance = 1.5f;

    Animator animator;

    public bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(FPSCamera.transform.position, transform.position); //checks the distance from the object to the player
        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit);
        if (distanceToTarget < distance)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                if (hit.transform.parent.name == "Locker" || hit.transform.parent.name == "Safe")
                {
                    canInteract = !canInteract;
                }
            }

            Outline(hit.transform.parent.name);
        }

        Interact();
    }
    
    void Interact()
    {
        if (canInteract)
        {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    animator.SetTrigger("Left");
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    animator.SetTrigger("Right");
                }

        }

        if (player.GetComponent<Subtitles>().dialogue == "")
            player.GetComponent<FirstPersonMovement>().enabled = !canInteract;
    }

    void Outline(string name)
    {
        if (name == gameObject.name)
        gameObject.GetComponent<Outline>().enabled = true;
    }
}
