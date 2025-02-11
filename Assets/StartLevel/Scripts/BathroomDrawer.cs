using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDrawer : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float distance = 1.5f;

    [SerializeField] GameObject firstInteract;

    [SerializeField] AudioClip sound;
    AudioSource audioSource;


    [SerializeField] Animator animator; //only if the object doesnt have attached animator
    bool opened;
    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        audioSource = GetComponent<AudioSource>();
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(FPSCamera.transform.position, transform.position); //checks the distance from the object to the player
        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit);
        if (distanceToTarget < distance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.name == "mf_book_01")
                {
                    GameObject physicalBook = GameObject.Find("mf_book_01");
                    Book book = GameObject.Find("Book").GetComponent<Book>();

                    book.FoundBook();
                    Destroy(physicalBook);
                    return;
                }

                if (hit.transform.parent.name == "T_sink" || hit.transform.parent.name == "To_showercurtain")
                {
                    Interact();
                }
            }

            Highlight(hit.transform.name);
        }
    }

    void Interact()
    {
        opened = !opened;
        animator.SetBool("Interact", opened);
        audioSource.clip = sound;
        audioSource.Play();
    }

    void Highlight(string name)
    {
        if (name == "mf_book_01")
        {
            firstInteract.GetComponent<Outline>().enabled = true;
        }

        else if (name == "T_sink")
        {
            firstInteract.GetComponent<Outline>().enabled = true;
        }

        else if (name == "To_showercurtain")
        {
            firstInteract.GetComponent<Outline>().enabled = true;
        }

    }
}
