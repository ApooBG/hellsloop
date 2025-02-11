using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //[SerializeField] float soundDelay = 0.1f;
    [SerializeField] ParticleSystem fireFlash;
    [SerializeField] float fireRate = 5f;
    [SerializeField] Camera FPSCamera;

    [SerializeField] GameObject boss;
    [SerializeField] GameObject devil;
    [SerializeField] AudioClip gunshot;
    [SerializeField] AudioClip reload;


    AudioSource audioSource;


    Ammo ammo;
    float nextTimeToFire = 0f;
    BossHealth bossHealth;
    HealthDevil devilHealth;

    List<float> listOfDamage;
    


    int damageIndex;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = boss.GetComponent<BossHealth>();
        devilHealth = devil.GetComponent<HealthDevil>();
        ammo = GetComponent<Ammo>();
        audioSource = gameObject.GetComponent<AudioSource>();

        listOfDamage = new List<float>()
        {
            18,
            20,
            20,
            20,
            22,
            22,
            24,
            18,
            20,
            20,
            20,
            18,
            45,
            46,
            43,
            60
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time >= nextTimeToFire)
        {
            ammo.Reload(audioSource, reload);
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (ammo.HasAmmo() == true)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shooting();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopSound();
        }
    }

    void Shooting()
    {

        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit);
        fireFlash.Play();
        damageIndex = Random.Range(0, listOfDamage.Count);
        if (hit.transform.tag == "Boss")
        {
            bossHealth.TakeDamage(listOfDamage[damageIndex]);
        }

        else if (hit.transform.tag == "Devil")
        {
            hit.transform.GetComponent<HealthDevil>().Damage(listOfDamage[damageIndex]);
            //devilHealth.Damage(damage);
        }

        if (!audioSource.isPlaying)
        {
           // audioSource.loop = false;
            audioSource.clip = gunshot;
        audioSource.Play();
            //audioSource.PlayOneShot(gunshot);
        }
    }

    void StopSound()
    {
        audioSource.Stop();
    }
}
