using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBirdTimeline : MonoBehaviour
{
    [SerializeField] GameObject bird;
    [SerializeField] int animationNumber;
    [SerializeField] GameObject key;
    BirdTimeline birdTimeline;

    // Start is called before the first frame update
    void Start()
    {
        birdTimeline = bird.GetComponent<BirdTimeline>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (animationNumber == 1)
            {
                birdTimeline.PlayFirstClip();
            }

            if (animationNumber == 2)
            {
                if (key.GetComponent<Keys>().canActivateBird2)
                    birdTimeline.PlaytSecondClip();
            }
        }
    }
}
