using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] GameObject devilFight;
    [SerializeField] AudioClip devilMusic;
    [SerializeField] AudioClip lofiMusic;


    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (devilFight.active)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = devilMusic;
                audioSource.volume = 0.141F;
                audioSource.Play();
            }
        }

        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = lofiMusic;
                audioSource.volume = 0.039F;
                audioSource.Play();
            }
        }
    }
}
