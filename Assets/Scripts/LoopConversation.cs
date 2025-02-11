using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopConversation : MonoBehaviour
{
    [SerializeField] GameObject player;
    int i = 0;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (time > 60)
        {
            if (collision.gameObject.tag == "Player")
            {
                Subtitles s = player.GetComponent<Subtitles>();
                if (i == 4)
                {
                    return;
                }

                i++;
                s.dialogue = $"suicideLoop{i}";
                time = 0;
                s.freeze = false;
            }
        }
    }
}
