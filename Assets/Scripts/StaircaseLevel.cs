using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseLevel : MonoBehaviour
{
    public bool move;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 targetPlayerPosition;

    Vector3 startingPosition;
    bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
        startingPosition = gameObject.transform.localPosition;
        targetPosition = new Vector3(10.253418F, -4.64816475F, 12.1276159F);
        targetPlayerPosition = new Vector3(46.2846298F, -18.8641167F, -523.892395F);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (gameObject.transform.localPosition != targetPosition)
            {
                gameObject.transform.localPosition = targetPosition;
                if (!moved)
                {
                    player.transform.position = targetPlayerPosition;
                }
                
                moved = true;
            }
        }

        else
        {
            if (gameObject.transform.localPosition != startingPosition)
            {
                gameObject.transform.localPosition = startingPosition;
                moved = false;
            }
        }
    }
}
