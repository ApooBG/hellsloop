using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float distance;

    [SerializeField] string objectName;

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
            Highlight(hit.transform.name);

            if (hit.transform.name == "pole")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(this);
                }
            }
        }
    }


    void Highlight(string name)
    {
        if (name == objectName)
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }
    }
}
