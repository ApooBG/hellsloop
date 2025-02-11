using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAtStart : MonoBehaviour
{
    StaircaseLevel staircase;
    // Start is called before the first frame update
    void Start()
    {
        staircase = GameObject.Find("Staircase").GetComponent<StaircaseLevel>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            staircase.move = false;
        }
    }
}
