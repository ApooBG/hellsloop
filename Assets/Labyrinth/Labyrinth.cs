using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject firstStage;
    [SerializeField] GameObject secondStage;
    [SerializeField] GameObject thirdStage;
    [SerializeField] GameObject fourthStage;
    [SerializeField] GameObject fifthStage;
    [SerializeField] GameObject player;

    [SerializeField] GameObject startWall;


    [SerializeField] List<GameObject> stages;
    PoolLabyrinth poolLabyrinth;

    public bool start;
    public bool hasStake;

    float time;


    // Start is called before the first frame update
    void Start()
    {
        start = false;
        hasStake = false;

        poolLabyrinth = player.GetComponent<PoolLabyrinth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (startWall.active == false)
            {
                startWall.SetActive(true);
            }

            if (hasStake)
            {
                time += Time.deltaTime;

                CheckLogic();
            }

            EnableStage();
        }
    }

    void CheckLogic()
    {
        int timeInSeconds = Convert.ToInt32(time);
        //Debug.Log(timeInSeconds/60);

        if (timeInSeconds > 3 && timeInSeconds < 30)
        {
            firstWall.transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }

        if (timeInSeconds / 60 == 2)
        {
            firstStage.SetActive(true);
        }

        if (timeInSeconds / 60 == 6)
        {
            secondStage.SetActive(true);
        }

        if (timeInSeconds / 60 == 10)
        {
            thirdStage.SetActive(true);
        }

        if (timeInSeconds / 60 == 15)
        {
            fourthStage.SetActive(true);
        }

        if (timeInSeconds / 60 == 20)
        {
            fifthStage.SetActive(true);
        }
    }

    void EnableStage()
    {
        int index = CheckStage();
        if (index != -1)
        {
            if (index == 0)
            {
                for (int i = 0; i < stages.Count; i++)
                {
                    if (i != index && i != index + 1)
                    {
                        stages[i].SetActive(false);
                    }

                    else
                    {
                        stages[i].SetActive(true);
                    }
                }
            }

            else if (index == 5)
            {
                for (int i = 0; i < stages.Count; i++)
                {
                    if (i != index && i != index - 1)
                    {
                        stages[i].SetActive(false);
                    }

                    else
                    {
                        stages[i].SetActive(true);
                    }
                }
            }

            else
            {
                for (int i = 0; i < stages.Count; i++)
                {
                    if (i != index && i != index+1 && i != index-1)
                    {
                        stages[i].SetActive(false);
                    }
                    
                    else
                    {
                        stages[i].SetActive(true);
                    }
                }
            }
        }
    }

    int CheckStage()
    {
        string stage = poolLabyrinth.currentStage;

        if (stage == "First Stage")
        {
            return 0;
        }

        if (stage == "Second Stage")
        {
            return 1;
        }

        if (stage == "Third Stage")
        {
            return 2;
        }

        if (stage == "Fourth Stage")
        {
            return 3;
        }

        if (stage == "Fifth Stage")
        {
            return 4;
        }

        if (stage == "End Stage")
        {
            return 5;
        }

        return -1;
    }
}
