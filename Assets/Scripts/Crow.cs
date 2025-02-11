using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] GameObject subtitles;
    [SerializeField] GameObject help;


    void Start()
    {

    }

    public void ToggleSubtitles(bool toggleSubtitles)
    {
        subtitles.SetActive(toggleSubtitles);
    }

    public void ToggleHelp(bool toggleHelp)
    {
        help.SetActive(toggleHelp);
    }
}
