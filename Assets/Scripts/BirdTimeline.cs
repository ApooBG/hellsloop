using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BirdTimeline : MonoBehaviour
{
    [SerializeField] PlayableAsset firstClip;
    [SerializeField] PlayableAsset secondClip;
    [SerializeField] PlayableAsset thirdClip;

    [SerializeField] Animator animator;

    int nextTimeline;

    PlayableDirector director;
    float time;
    float anotherAnimationTime;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.enabled = false;
        time = 0;
        anotherAnimationTime = 0;
        nextTimeline = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (director.isActiveAndEnabled)
        {
            time += Time.deltaTime;
            director.time = time;

            if (time > director.playableAsset.duration)
            {
                director.enabled = false;
            }
        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "watch01")
        {
            anotherAnimationTime += Time.deltaTime;
            if (anotherAnimationTime > animator.GetCurrentAnimatorClipInfo(0)[0].clip.length)
            {
                animator.SetTrigger("peck");
                anotherAnimationTime = 0;
            }
        }
    }


    public void PlayFirstClip()
    {
        if (nextTimeline == 1)
        PlayClip(firstClip);
    }

    public void PlaytSecondClip()
    {
        if (nextTimeline == 2)
            PlayClip(secondClip);
    }

    public void PlayThirdClip()
    {
        if (nextTimeline == 3)
            PlayClip(thirdClip);
    }

    void PlayClip(PlayableAsset playableAsset)
    {
        director.enabled = true;
        director.playableAsset = playableAsset;
        time = 0;
        nextTimeline++;
        director.Play();
    }
}
