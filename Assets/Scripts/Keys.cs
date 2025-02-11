using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float distance;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] TextMeshProUGUI help;

    [SerializeField] bool addToInventory;

    [SerializeField] GameObject key;

    public bool canActivateBird2;


    AudioSource audioSource;
    bool canPickUp;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canPickUp = false;
        canActivateBird2 = false;
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
                Interact();
            }

            Highlight(hit.transform.name);
        }

        if (audioSource.clip != null && !audioSource.isPlaying && canPickUp == true)
        {
            try
            {
                help.gameObject.SetActive(false);
            }
            catch
            {
                Destroy(door);
            }
            gameObject.SetActive(false);
        }
    }


    void Interact()
    {
        if (addToInventory)
            player.GetComponent<Inventory>().inventory.Add(gameObject);
        else
            canActivateBird2 = true;
        

        audioSource.clip = clip;
        audioSource.Play();
        canPickUp = true;
    }

    void Highlight(string name)
    {
        if (name == "Key")
        gameObject.GetComponent<Outline>().enabled = true;

    }
}
