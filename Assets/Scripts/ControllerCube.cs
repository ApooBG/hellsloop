using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCube : MonoBehaviour
{
    [SerializeField] GameObject controlMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "ControllerMenuCube")
                controlMenuUI.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.name == "ControllerMenuCube")
            controlMenuUI.SetActive(false);
    }
}
