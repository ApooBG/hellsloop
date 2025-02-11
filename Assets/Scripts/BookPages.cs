using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPages : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float distance = 0.5f;
    [SerializeField] AudioClip clip;

    AudioSource audioSource;
    Book book;

    void Start()
    {
       book = GameObject.Find("Book").GetComponent<Book>();
       audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            float distanceToTarget = Vector3.Distance(FPSCamera.transform.position, transform.position); //checks the distance from the object to the player
            RaycastHit hit;
            Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit);
            if (hit.transform.name.Contains("Page"))
            {
                if (distanceToTarget < distance)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        book.FoundPage(Convert.ToInt32(gameObject.name.Substring(4, gameObject.name.Length - 4)));
                        book.FoundPage(Convert.ToInt32(gameObject.name.Substring(4, gameObject.name.Length - 4)) + 1);
                        audioSource.clip = clip;
                        audioSource.Play();
                    }

                    Outline();
                }
            }

            if (audioSource.clip != null && !audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        catch
        {

        }

    }
    
    void Outline()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }
}
