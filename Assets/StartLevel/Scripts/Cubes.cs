using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> puzzleTemplate;
    [SerializeField] GameObject puzzleCubes;
    [SerializeField] GameObject wall;

    [SerializeField] GameObject bird;


    Subtitles s;


    bool playing;
    bool canDie;

    int currentPosition;
    float distanceToPlayer;

    float xValue;

    private void Start()
    {
        playing = false;
        s = player.GetComponent<Subtitles>();
        currentPosition = 0;
        canDie = false;

        xValue = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (Input.GetKeyDown(KeyCode.K))
        {
            playing = !playing;
        }

        if (distanceToPlayer > 5F)
        {
            playing = false;
            return;
        }

        if (playing)
        {
            Puzzle();
            Debug.Log(currentPosition);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move('w');
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move('a');
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move('d');
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move('s');
            }
        }


        if (currentPosition == 20)
        {
            
            s.dialogue = "solvedSmallPuzzle";
            s.freeze = false;
        }

        if (s.dialogue == "solvedSmallPuzzle")
        {
            wall.gameObject.SetActive(false);
            bird.GetComponent<BirdTimeline>().PlayThirdClip();
        }
    }

    void Move(char keyPressed)
    {
        currentPosition = Convert.ToInt32(currentPosition);
        if (currentPosition < 0)
        {
            currentPosition = 0;
        }

        if (keyPressed == 'w')
        {
            canDie = true;
            if (currentPosition < 16)
            {
                currentPosition += 5;
            }
        }

        if (keyPressed == 'a')
        {
            canDie = true;
            if ((currentPosition != 5 && currentPosition != 10 && currentPosition != 15) || currentPosition == 0)
            {
                currentPosition += 1;
            }
        }

        if (keyPressed == 's')
        {
            canDie = true;
            if (currentPosition > 5)
            {
                currentPosition -= 5;
            }
        }

        if (keyPressed == 'd')
        {
            canDie = true;
            if (currentPosition != 1 && currentPosition != 6 && currentPosition != 11 && currentPosition != 16)
            {
                currentPosition -= 1;
            }
        }


        gameObject.transform.position = new Vector3(puzzleTemplate[currentPosition].transform.position.x, puzzleTemplate[currentPosition].transform.position.y, gameObject.transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PuzzleCube" && canDie)
        {
            currentPosition = 0;
            Move('h');
        }
    }

    void Puzzle()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            canDie = false;
            puzzleCubes.GetComponent<Animator>().ResetTrigger("FirstButton");
            puzzleCubes.GetComponent<Animator>().ResetTrigger("SecondButton");
            puzzleCubes.GetComponent<Animator>().ResetTrigger("ThirdButton");
            puzzleCubes.GetComponent<Animator>().ResetTrigger("FourthButton");

            puzzleCubes.GetComponent<Animator>().SetTrigger("NormalState");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            puzzleCubes.GetComponent<Animator>().ResetTrigger("NormalState");
            puzzleCubes.GetComponent<Animator>().SetTrigger("FirstButton");
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            puzzleCubes.GetComponent<Animator>().ResetTrigger("NormalState");
            puzzleCubes.GetComponent<Animator>().SetTrigger("SecondButton");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            puzzleCubes.GetComponent<Animator>().ResetTrigger("NormalState");
            puzzleCubes.GetComponent<Animator>().SetTrigger("ThirdButton");
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            puzzleCubes.GetComponent<Animator>().ResetTrigger("NormalState");
            puzzleCubes.GetComponent<Animator>().SetTrigger("FourthButton");
        }

    }
}
