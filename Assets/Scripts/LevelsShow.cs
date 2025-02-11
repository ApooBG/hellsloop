using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelsShow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject weapon;
    [SerializeField] TextMeshProUGUI ammo;
    [SerializeField] GameObject bossHealth;




    [SerializeField] GameObject startLevel;
    [SerializeField] GameObject cubesLevel;
    [SerializeField] GameObject labyrinthLevel;
    [SerializeField] GameObject gameWalls;

    [SerializeField] GameObject suicideLevel;
    [SerializeField] GameObject bossLevel;

    Vector3 bossPosition;

    bool canEnterBoss;
    // Start is called before the first frame update
    void Start()
    {
        canEnterBoss = false;
        bossPosition = new Vector3(-47.225666f, -468.660004f, -1348.44934f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnterBoss)
        {
            if (player.transform.position.y < -30)
            {
                bossLevel.SetActive(true);
                player.transform.position = bossPosition;
                weapon.SetActive(true);
                ammo.gameObject.SetActive(true);
                bossHealth.SetActive(true);
                gameObject.GetComponent<LevelsShow>().enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.name == "LabStart")
            {
                gameWalls.GetComponent<Labyrinth>().start = true;
                startLevel.SetActive(false);
                cubesLevel.SetActive(false);
            }

            if (gameObject.name == "LabEnd")
            {
                suicideLevel.SetActive(true);
            }

            if (gameObject.name == "SuicideLevel")
            {
                labyrinthLevel.SetActive(false);
                player.GetComponent<PoolLabyrinth>().enabled = false;
                canEnterBoss = true;
            }

        }
    }
}
