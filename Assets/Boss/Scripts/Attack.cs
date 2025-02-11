using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool isAttacking;
    Transform target;
    PlayerHealth playerHealth;

    private void Start()
    {
        target = GameObject.Find("First Person Controller").transform;  
        playerHealth = GameObject.Find("First Person Controller").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
      //  Debug.Log(Vector3.Angle(transform.forward, target.position - transform.position));
    }
    // Start is called before the first frame update

}
