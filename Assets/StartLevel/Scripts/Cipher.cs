using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipher : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bird;
    [SerializeField] GameObject keyObject;

    BirdTimeline birdTimeline;
    List<int> cipher;
    List<int> key;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        birdTimeline = bird.GetComponent<BirdTimeline>();
        animator = GetComponent<Animator>();
        keyObject.SetActive(false);


        cipher = new List<int>();
        key = new List<int>()
        {
            0, 0, 1, 0, 1, 1
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckCombination())
        {
            animator.SetBool("Unlocked", true);
            player.GetComponent<FirstPersonMovement>().enabled = true;
            gameObject.GetComponent<Cipher>().enabled = false;
        }
    }


    bool CheckCombination()
    {
        int k = -1;
        if (cipher.Count > 5)
        {
            for (int i = cipher.Count - 6; i < cipher.Count; i++)
            {
                k++;
                if (cipher[i] != key[k])
                {
                    return false;
                }
            }
            CorrectCombination();
            return true;
        }

        return false;
    }

    void CorrectCombination()
    {
        birdTimeline.PlayFirstClip();
        keyObject.SetActive(true);
        gameObject.GetComponent<SafeBehaviour>().canInteract = false;
    }

    public void AddToCipher(int number)
    {
        //0 is left and 1 is right
        cipher.Add(number);
        Debug.Log(number);
    }
}
