using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject puzzle1;
    [SerializeField] Animator puzzle1Animator;
    [SerializeField] Animator puzzle2Animator;
    [SerializeField] GameObject player;

    public bool playerCanPlay;

    GameObject puzzle2;
    Mover mover;
    public List<bool> isActivated;

    public bool canMove = true;

    bool isNormal = true;
    bool puzzleActive = true;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        puzzle2 = GameObject.Find("Puzzle2");
        puzzle1.SetActive(puzzleActive);
        puzzle2.SetActive(!puzzleActive);

        mover = player.GetComponent<Mover>();
        playerCanPlay = false;

        isActivated = new List<bool>()
        {
            true,
            false,
            false,
            false,
            false,
            false
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanPlay)
        {
            if (puzzle1.active)
            {
                CheckKeys(puzzle1Animator);
            }

            else
            {
                CheckKeys(puzzle2Animator);
            }
        }
    }

    void CheckKeys(Animator mainAnimator)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipAnimation(mainAnimator);
        }

        if (!canMove)
        {
            time += Time.deltaTime;
        }

        if (time >= mainAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length)
        {
            canMove = true;
            time = 0f;
        }

        if (isNormal)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (CheckActivated(0))
                    ChangeVariant(mainAnimator, KeyCode.F1);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (CheckActivated(1))
                    ChangeVariant(mainAnimator, KeyCode.F2);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                if (CheckActivated(2))
                    ChangeVariant(mainAnimator, KeyCode.F3);
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                if (CheckActivated(3))
                    ChangeVariant(mainAnimator, KeyCode.F4);
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                if (CheckActivated(4))
                    ChangeVariant(mainAnimator, KeyCode.F5);
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                if (CheckActivated(5))
                    ChangeVariant(mainAnimator, KeyCode.F6);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Rotate(mainAnimator);
                Invoke("ChangeVisibility", 0.5F);
                isNormal = true;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.F12))
        {
            isNormal = true;
            ResetPuzzle(mainAnimator);
        }
    }



    bool CheckActivated(int position)
    {
        return isActivated[position];
    }

    void Rotate(Animator animator)
    {
        puzzle2Animator.SetTrigger("Rotate");
        puzzle1Animator.SetTrigger("Rotate");
    }

    void ChangeVariant(Animator animator, KeyCode keyCode)
    {
        mover.canCollide = false;
        isNormal = false;
        canMove = false;
        if (keyCode == KeyCode.F1)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Blue");
        }

        if (keyCode == KeyCode.F2)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Green");
        }

        if (keyCode == KeyCode.F3)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Orange");
        }

        if (keyCode == KeyCode.F4)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Purple");
        }

        if (keyCode == KeyCode.F5)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("White");
        }

        if (keyCode == KeyCode.F6)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Yellow");
        }
    }

    void ResetPuzzle(Animator animator)
    {
        mover.canCollide = false;
        animator.ResetTrigger("Blue");
        animator.ResetTrigger("Green");
        animator.ResetTrigger("Orange");
        animator.ResetTrigger("Purple");
        animator.ResetTrigger("White");
        animator.ResetTrigger("Yellow");
        animator.SetTrigger("Normal");
    }

    void ChangeVisibility()
    {
        puzzleActive = !puzzleActive;

        puzzle1.SetActive(puzzleActive);
        puzzle2.SetActive(!puzzleActive);
    }

    private void SkipAnimation(Animator mainAnimator)
    {
        mover.playerCanPlay = true;
        canMove = true;
        time = 0f;
        mainAnimator.Play(mainAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 1f);
    }
}
