using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightstand : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] GameObject player;
    [SerializeField] float distance = 1.5f;

    [SerializeField] GameObject top_drawer;
    [SerializeField] GameObject bottom_drawer_L;
    [SerializeField] GameObject bottom_drawer_R;

    [SerializeField] AudioClip top_drawer_open;
    [SerializeField] AudioClip bottom_drawer_open;

    AudioSource audioSource;


    Animator animator;
    bool openedTop = false;
    bool openedBottom = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(FPSCamera.transform.position, transform.position); //checks the distance from the object to the player
        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit);
        if (distanceToTarget < distance)
        {
            if (hit.transform.name == "Nightstand_drawer")
            {
                Highlight("Top");
            }

            if (hit.transform.name.Contains("Nightstand_door_"))
            {
                Highlight("Bottom");
            }
        }
    }

    void Interact(string name)
    {
        if (name == "Top")
        {
            if (openedBottom == false)
            {
                openedTop = !openedTop;
                animator.SetBool("OpenTop", openedTop);
                audioSource.clip = top_drawer_open;
                audioSource.Play();
            }
        }

        else if (name == "Bottom")
        {
            if (openedTop == false)
            {
                openedBottom = !openedBottom;
                animator.SetBool("OpenBottom", openedBottom);

                audioSource.clip = bottom_drawer_open;
                audioSource.Play();
                if (gameObject.name == "Nightstand (1)")
                {
                    Subtitles s = player.GetComponent<Subtitles>();
                    s.dialogue = "thirdDialogue";
                    s.freeze = false;
                }
            }
        }
    }

    void Highlight(string name)
    {
        if (name == "Top")
        {
            top_drawer.GetComponent<Outline>().enabled = true;
        }

        else if (name == "Bottom")
        {
            bottom_drawer_L.GetComponent<Outline>().enabled = true;
            bottom_drawer_R.GetComponent<Outline>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(name);
        }
    }
}
