using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float distance = 3F;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (hit.transform.name == "Key" || hit.transform.name == "sm_key_01")
                {
                    Destroy(gameObject);
                    Destroy(door);
                }
            }

           // Outline(hit.transform.parent.name);
        }

       // Interact();
    }
}
