using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConversation : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] string dialogue;
    [SerializeField] bool freeze;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Subtitles s = player.GetComponent<Subtitles>();
            s.freeze = freeze;
            s.dialogue = dialogue;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Subtitles s = player.GetComponent<Subtitles>();
            s.freeze = freeze;
            s.dialogue = dialogue;
            Destroy(gameObject.GetComponent<SetConversation>());
        }
    }


}
