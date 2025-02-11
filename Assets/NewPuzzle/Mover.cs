using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leftMoves;
    [SerializeField] GameObject p;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject stairCase;
    [SerializeField] GameObject game;
    [SerializeField] GameObject labyrinth;


    List<Transform> listOfPositions;
    Puzzle puzzle;
    Controller controller;
    public int moves;
    bool start;
    public bool canCollide;
    public bool playerCanPlay;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = p.GetComponent<Puzzle>();

        controller = GameObject.Find("Game").GetComponent<Controller>();

        moves = 60;
        start = true;
        canCollide = false;
        playerCanPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (listOfPositions == null)
        {
            Invoke("GetList", 0.1F);
        }

        if (listOfPositions == null)
        {
            return;
        }

        if (controller.canMove)
        {
            if (playerCanPlay)
                KeyBinds();
        }


    }

    void KeyBinds()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            try
            {
                if (GetCubeNumber() + 1 == 11 || GetCubeNumber() + 1 == 22 || GetCubeNumber() + 1 == 33 || GetCubeNumber() + 1 == 44 || GetCubeNumber() + 1 == 55 || GetCubeNumber() + 1 == 66 || GetCubeNumber() + 1 == 77 || GetCubeNumber() + 1 == 88)
                {
                    Debug.Log(GetCubeNumber().ToString());
                    return;
                }

                Move(GetCubeNumber() + 1);
            }

            catch
            {
                Debug.Log("Cant move");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GetCubeNumber() + 1 == 12 || GetCubeNumber() + 1 == 23 || GetCubeNumber() + 1 == 34 || GetCubeNumber() + 1 == 45 || GetCubeNumber() + 1 == 56 || GetCubeNumber() + 1 == 67 || GetCubeNumber() + 1 == 78 || GetCubeNumber() + 1 == 89)
            {
                Debug.Log(GetCubeNumber().ToString());
                return;
            }

            try
            {
                Move(GetCubeNumber() - 1);
            }

            catch
            {
                Debug.Log("Cant move");
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            try
            {
                Move(GetCubeNumber() + 11);
            }

            catch
            {
                Debug.Log("Cant move");
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            try
            {
                Move(GetCubeNumber() - 11);
            }

            catch
            {
                Debug.Log("Cant move");
            }
        }


    }


    void GetList()
    {
        listOfPositions = puzzle.listOfPositions;
    }

    int GetCubeNumber()
    {
        int i = -1;
        foreach (Transform t in listOfPositions)
        {
            i++;
            if (t.position.y.ToString("0.00") == this.gameObject.transform.position.y.ToString("0.00") && t.position.x.ToString("0.00") == this.gameObject.transform.position.x.ToString("0.00"))
            {
                return i;
            }
        }

        return -1;
    }

    void CheckNumber(int number)
    {
        if (number == 99-1)
        {
            player.GetComponent<GameLogic>().enabled = false;
            stairCase.SetActive(true);
            game.SetActive(false);
            labyrinth.SetActive(true);


            player.GetComponent<GameLogic>().TogglePlay(true);

            player.GetComponent<PoolLabyrinth>().enabled = true;
            gameObject.SetActive(false);
            Subtitles s = player.GetComponent<Subtitles>();
            s.freeze = true;
            s.dialogue = "solvedBigPuzzle";
        }
    }

    void Move(int number)
    {
        if (moves > 0)
        {
            moves -= 1;
            leftMoves.text = moves.ToString();

            if (start)
            {
                this.gameObject.transform.position = new Vector3(listOfPositions[0].position.x, listOfPositions[0].position.y, this.gameObject.transform.position.z);

                canCollide = true;
                start = false;
                moves = moves--;
                leftMoves.text = moves.ToString();
            }

            else if (moves > 0)
            {
                this.gameObject.transform.position = new Vector3(listOfPositions[number].position.x, listOfPositions[number].position.y, this.gameObject.transform.position.z);
                canCollide = true;
            }
        }

        else Debug.Log("No more moves left.");


        CheckNumber(number);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (canCollide)
        {
            gameObject.transform.localPosition = new Vector3(-17.894F, -11.72196F, 63.654F);
            Debug.Log("Enter");
        }
    }
}
