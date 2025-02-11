using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScale : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -15.5F)
        {
            player.GetComponent<Jump>().jumpStrength = 6;
        }

        else if (player.transform.position.y > -20)
        {
            player.GetComponent<Jump>().jumpStrength = 4;
        }
    }
}
