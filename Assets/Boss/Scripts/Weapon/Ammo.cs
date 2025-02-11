using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] float startingFullAmmo;
    [SerializeField] float startingAmmoInYou;
    [SerializeField] float maxAmmo;

    float currentAmmo;
    float fullAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = startingAmmoInYou;
        fullAmmo = startingFullAmmo;
        ChangeAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasAmmo()
    {
        if (currentAmmo == 0)
        {
            return false;
        }

        if (currentAmmo == 0 && fullAmmo > maxAmmo)
        {
            Invoke("Reload", 0.3f);
        }

        else if (currentAmmo == 0 && fullAmmo <= maxAmmo)
        {
            Invoke("Reload", 0.3f);
        }

        if (currentAmmo > 0)
        {
            currentAmmo -= 1;
            ChangeAmmoText();
            if (currentAmmo == 0)
            {
                Invoke("Reload", 0.3f);
            }
            return true;
        }

        return false;
    }

    public void Reload(AudioSource source, AudioClip reload)
    {
        if (currentAmmo == maxAmmo)
        {
            return;
        }

        float amountReloading = maxAmmo - currentAmmo;
        if (fullAmmo >= amountReloading)
        {
            fullAmmo -= amountReloading;
            currentAmmo = maxAmmo;
        }

        else if (fullAmmo < amountReloading && fullAmmo > 0)
        {
            currentAmmo += amountReloading;
            fullAmmo = 0;
        }

        if (source.clip.name != reload.name || !source.isPlaying)
        {
            source.clip = reload;
            source.Play();
        }
        ChangeAmmoText();
    }

    void ChangeAmmoText()
    {
        if (fullAmmo == 0)
        {
            ammoText.text = currentAmmo.ToString();
        }

        else
        {
            ammoText.text = $"{currentAmmo} / {fullAmmo}";
        }
    }
}
