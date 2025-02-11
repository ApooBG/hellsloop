using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceMover : MonoBehaviour
{
    // Start is called before the first frame update
    bool goingLeft = true;
    [SerializeField] float maxLeft = 6f;
    [SerializeField] float maxRight = -4f;
    [SerializeField] float speed = 0.01f;
    [SerializeField] string direction;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 'X'.ToString())
        {
            float xValue = transform.localPosition.x;

            if (xValue >= maxRight)
            {
                goingLeft = true;
            }

            if (xValue <= maxLeft)
            {
                goingLeft = false;
            }


            if (goingLeft == true)
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            else
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }

        else if (direction == 'Z'.ToString())
        {
            float zValue = transform.localPosition.x;

            if (zValue >= maxRight)
            {
                goingLeft = true;
            }

            if (zValue <= maxLeft)
            {
                goingLeft = false;
            }


            if (goingLeft == true)
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            else
                gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

        }


        //transform.position = new Vector3(xValue, transform.position.y, transform.position.z);

    }
}
