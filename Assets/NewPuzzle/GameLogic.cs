using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator orangeAnimator;
    [SerializeField] Animator greenAnimator;
    [SerializeField] Animator purpleAnimator;
    [SerializeField] Animator whiteAnimator;
    [SerializeField] Animator yellowAnimator;
    [SerializeField] GameObject controllerHelpMenu;
    [SerializeField] TextMeshProUGUI help;
    Controller controller;
    Mover mover;

    public bool canMove;

    string collided = "";
    bool interact = false;


    GameObject greenKey;
    GameObject orangeKey;
    GameObject purpleKey;
    GameObject whiteKey;
    GameObject yellowKey;

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        help.gameObject.SetActive(false);
        mover = player.GetComponent<Mover>();

        controller = GameObject.Find("Game").GetComponent<Controller>();
        inventory = GetComponent<Inventory>();

        controllerHelpMenu.SetActive(false);

        greenKey = GameObject.Find("GreenKey");
        orangeKey = GameObject.Find("OrangeKey");
        purpleKey = GameObject.Find("PurpleKey");
        whiteKey = GameObject.Find("WhiteKey");
        yellowKey = GameObject.Find("YellowKey");

        greenKey.gameObject.SetActive(false);
        orangeKey.gameObject.SetActive(false);
        purpleKey.gameObject.SetActive(false);
        whiteKey.gameObject.SetActive(false);
        yellowKey.gameObject.SetActive(false);

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact = true;
        }

        if (controllerHelpMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                canMove = !canMove;
                TogglePlay(canMove);
            }
        }
    }


    public void TogglePlay(bool enabled)
    {
        controller.playerCanPlay = !mover.playerCanPlay;
        mover.playerCanPlay = !mover.playerCanPlay;
        GetComponent<FirstPersonMovement>().enabled = enabled;
        GetComponent<Jump>().enabled = enabled;
        GetComponent<Crouch>().enabled = enabled;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ControlMenu")
        {
            controllerHelpMenu.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Key")
        {
            ShowHelp("Press 'E' to pickup the key");
            collided = "key";
            if (interact == true)
            {
                ColliderExit();
            }
        }

        if (other.gameObject.name.Contains("Lock"))
        {
            string type = other.gameObject.name.Substring(5);

            if (inventory.inventory.Find(x => x.name == "Key"))
            {
                ShowHelp("Press 'E' to use the key");
                if (interact == true)
                {
                    if (type == "Blue")
                    {
                        controller.isActivated[0] = true;
                    }

                    if (type == "Green")
                    {
                        greenKey.gameObject.SetActive(true);
                        greenAnimator.SetTrigger("Green");
                        controller.isActivated[1] = true;

                        foreach (GameObject o in inventory.inventory)
                        {
                            if (o.name == "Key")
                            {
                                inventory.inventory.Remove(o);
                                break;
                            }
                        }
                    }

                    if (type == "Orange")
                    {
                        orangeKey.gameObject.SetActive(true);
                        orangeAnimator.SetTrigger("Orange");
                        controller.isActivated[2] = true;

                        foreach (GameObject o in inventory.inventory)
                        {
                            if (o.name == "Key")
                            {
                                inventory.inventory.Remove(o);
                                break;
                            }
                        }
                    }

                    if (type == "Purple")
                    {
                        purpleKey.gameObject.SetActive(true);
                        purpleAnimator.SetTrigger("Purple");
                        controller.isActivated[3] = true;

                        foreach (GameObject o in inventory.inventory)
                        {
                            if (o.name == "Key")
                            {
                                inventory.inventory.Remove(o);
                                break;
                            }
                        }
                    }

                    if (type == "White")
                    {
                        whiteKey.gameObject.SetActive(true);
                        whiteAnimator.SetTrigger("White");
                        controller.isActivated[4] = true;

                        foreach (GameObject o in inventory.inventory)
                        {
                            if (o.name == "Key")
                            {
                                inventory.inventory.Remove(o);
                                break;
                            }
                        }
                    }

                    if (type == "Yellow")
                    {
                        yellowKey.gameObject.SetActive(true);
                        yellowAnimator.SetTrigger("Yellow");
                        controller.isActivated[5] = true;

                        foreach (GameObject o in inventory.inventory)
                        {
                            if (o.name == "Key")
                            {
                                inventory.inventory.Remove(o);
                                break;
                            }
                        }
                    }

                    ColliderExit();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ColliderExit();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ControllerMenuCube")
        {
            controllerHelpMenu.SetActive(false);
        }
    }

    void ShowHelp(string message)
    {
        help.text = message;
        help.gameObject.SetActive(true);
    }

    void ColliderExit()
    {
        collided = "";
        interact = false;
        help.gameObject.SetActive(false);
    }
}
