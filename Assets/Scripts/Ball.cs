using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);

    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Underworld")
        {
            SceneManager.LoadScene("MainScene");
        }

        if (collision.gameObject.name.Contains("Cube"))
        {
            SceneManager.LoadScene("Obstacle");
        }


        if (collision.gameObject.name.Contains("Finish"))
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Obstacle");
        }

    }
}
