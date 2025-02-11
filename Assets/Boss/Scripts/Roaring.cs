using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaring : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;

    [SerializeField] float minZ;
    [SerializeField] float maxZ;

    [SerializeField] float yValue;

    [SerializeField] GameObject demon;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    List<GameObject> listOfDemons;


    Animator animator;
    bool roar;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        listOfDemons = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Roaring")
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        if (roar)
        {
            animator.SetBool("Roaring", true); //activates the roaring animation
            roar = false; 
        }

        else
        {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Roaring") //prevent bugs
            {
                animator.SetBool("Roaring", false);
            }
        }

        Debug.Log(listOfDemons.Count);
    }

    public void Roar() //when this method is called, the roaring animation is activated and spawning enemies
    {
        roar = true;
        audioSource.Stop();
    }

    public void SpawningEnemies(int numberOfEnemies) 
    {
        for (int i = 0; i < numberOfEnemies; i++) //used to translate the number of enemies to spawn.
        {
            float xValue = Random.Range(minX, maxX);
            float zValue = Random.Range(minZ, maxZ);

            GameObject demonCopy = Instantiate(demon);
            demonCopy.transform.position = new Vector3(xValue, yValue, zValue);
            listOfDemons.Add(demonCopy);
        }
    }

    public void RemoveFromList()
    {
        listOfDemons.RemoveAt(listOfDemons.Count - 1);
        if (listOfDemons.Count == 0)
        {
            ActivateSpecialAttack();
        }
    }

    void ActivateSpecialAttack()
    {
        animator.SetBool("Run", true);
    }
}
