using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool canPress = false;
    Crow crow;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        crow = player.GetComponent<Crow>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowSubtitles();
    }

    void ShowSubtitles()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canPress = false;
                crow.ToggleSubtitles(true);
                crow.ToggleHelp(false);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crow")
        {
            crow.ToggleSubtitles(false);
            crow.ToggleHelp(true);
            canPress = true;
        }

        if (collision.gameObject.name == "Staircase")
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Crow")
        {
            crow.ToggleHelp(false);
            if (canPress == false)
            {
                yield return new WaitForSeconds(3);
                crow.ToggleSubtitles(false);
            }

        }

    }
}
