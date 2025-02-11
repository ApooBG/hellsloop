using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    StaircaseLevel staircase;
    // Start is called before the first frame update
    void Start()
    {
        staircase = GameObject.Find("Staircase").GetComponent<StaircaseLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            staircase.move = true;
            Debug.Log("Moved");
        }
    }
}
