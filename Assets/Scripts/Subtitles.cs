using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Subtitles : MonoBehaviour
{
    class Subtitle {
        public string subtitle;
        public float waitTimeInSeconds;
        public string name;

        public string dialogueName;

        public Subtitle (string name, string subtitle, float waitTimeInSeconds, string dialogueName)
        {
            this.name = name;
            this.subtitle = subtitle;
            this.waitTimeInSeconds = waitTimeInSeconds;
            this.dialogueName = dialogueName;
        }

        public Subtitle()
        {

        }
    }


    [SerializeField] List<Subtitle> listOfSubtitles;
    [SerializeField] TextMeshProUGUI subtitleObject;
    [SerializeField] Animator birdAnimator;

    FirstPersonMovement movement;
    [SerializeField] public bool haveSubtitles;

    public string dialogue;
    public bool freeze;

    bool birdTalk;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = "firstDialogue";
        listOfSubtitles = new List<Subtitle>();
        movement = gameObject.GetComponent<FirstPersonMovement>();
        birdTalk = false;
        freeze = true;

        AddSubtitles();

        ClearSubtitles();
        PlayNext("firstDialogue", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (subtitleObject.text == "")
        {
            PlayNext(dialogue, freeze);
        }

        if (birdTalk)
        {
            birdAnimator.SetTrigger("sing");
        }

    }

    public void PlayNext(string name, bool freeze)
    {
        if (haveSubtitles)
        {
            if (freeze)
            {
                movement.enabled = false;
            }
            Subtitle s = null;

            try
            {
                s = listOfSubtitles.Find(x => x.dialogueName == name);
            }

            catch
            {

            }

            if (s == null)
            {
                dialogue = "";
                movement.enabled = true;
            }

            else
            {
                if (name == s.dialogueName)
                {
                    subtitleObject.text = $"{s.name}: {s.subtitle}";
                    if (s.name == "Bird" || s.name == "Garry")
                    {
                        birdTalk = true;
                    }

                    else if (birdTalk)
                        birdTalk = false;
                    StartCoroutine(Wait(s.waitTimeInSeconds));
                    listOfSubtitles.Remove(s);
                }
            }
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ClearSubtitles();
    }
    void ClearSubtitles()
    {
        subtitleObject.text = "";
        birdTalk = false;
    }

    void AddSubtitles()
    {

        Subtitle firstDialogue1 = new Subtitle("You", "Where am I?", 3, "firstDialogue");
        Subtitle firstDialogue2 = new Subtitle("Bird", "Hi!", 1, "firstDialogue");
        Subtitle firstDialogue3 = new Subtitle("You", "A talking bird? What's happening, am I dreaming?", 3, "firstDialogue");
        Subtitle firstDialogue4 = new Subtitle("Bird", "I am Garry. I can explain everything, but you need to calm down first.", 4, "firstDialogue");
        Subtitle firstDialogue5 = new Subtitle("You", "I am fine, just explain to me what's happening.", 3, "firstDialogue");
        Subtitle firstDialogue6 = new Subtitle("Garry", "Well, it's simple.", 2, "firstDialogue");
        Subtitle firstDialogue7 = new Subtitle("Garry", "You died, Tom. And you are in Hell.", 3, "firstDialogue");
        Subtitle firstDialogue8 = new Subtitle("Tom", "What? I don't remember dying and how do you know my name.", 4, "firstDialogue");
        Subtitle firstDialogue9 = new Subtitle("Garry", "Since you parted with your body, you no longer have your memories. All you have is your name and your past regrets.", 5, "firstDialogue");
        Subtitle firstDialogue10 = new Subtitle("Tom", "My regrets? I don't remember anything at all.", 3, "firstDialogue");
        Subtitle firstDialogue11 = new Subtitle("Garry", "You will, just give it time.", 2, "firstDialogue");
        Subtitle firstDialogue12 = new Subtitle("Tom", "(takes a big breath)", 1, "firstDialogue");
        Subtitle firstDialogue13 = new Subtitle("Tom", "So... How do I get out of this place?", 3, "firstDialogue");
        Subtitle firstDialogue14 = new Subtitle("Garry", "How the feathers should I know? I can only tell you what you need to do.", 5, "firstDialogue");
        Subtitle firstDialogue15 = new Subtitle("Garry", "For now just look around", 2, "firstDialogue");

        Subtitle secondDialogue1 = new Subtitle("Garry", "You are a lucky man, most of the souls don't have that book.", 2, "secondDialogue");
        Subtitle secondDialogue2 = new Subtitle("Garry", "It represents higher chances of your soul's salvation and it will guide you along the way.", 2, "secondDialogue");
        Subtitle secondDialogue3 = new Subtitle("Tom", "Unluckily enough there are no pages.", 2, "secondDialogue");
        Subtitle secondDialogue4 = new Subtitle("Garry", "Hmm, if the book is here then the pages must be around as well. Take a look around.", 3, "secondDialogue");

        Subtitle thirdDialogue1 = new Subtitle("Tom", "What is this", 1, "thirdDialogue");
        Subtitle thirdDialogue2 = new Subtitle("Garry", "A safe. It keeps the key for escaping this room.", 2, "thirdDialogue");
        Subtitle thirdDialogue3 = new Subtitle("Tom", "How do I open it?", 2, "thirdDialogue");
        Subtitle thirdDialogue4 = new Subtitle("Garry", "You need the right combination. I wonder if the book can help.", 3, "thirdDialogue");

        Subtitle roomEscapeDialogue1 = new Subtitle("Tom", "Garry!", 1, "roomEscapeDialogue");
        Subtitle roomEscapeDialogue2 = new Subtitle("Garry", "Yes?", 1, "roomEscapeDialogue");
        Subtitle roomEscapeDialogue3 = new Subtitle("Tom", "How did you end up here? With me... Isn't this supposed to be my personal Hell?", 3, "roomEscapeDialogue");
        Subtitle roomEscapeDialogue4 = new Subtitle("Garry", "It's nothing you need to worry about, not right now. Focus on finding the next challenge.", 3, "roomEscapeDialogue");
        Subtitle roomEscapeDialogue5 = new Subtitle("Garry", "I will wait you there.", 3, "roomEscapeDialogue");


        Subtitle foundSmallPuzzle1 = new Subtitle("Tom", "There it is. What's that?", 3, "foundSmallPuzzle");
        Subtitle foundSmallPuzzle2 = new Subtitle("Garry", "It's another puzzle that this places created for you. I can see another page from here.", 3, "foundSmallPuzzle");
        Subtitle foundSmallPuzzle3 = new Subtitle("Tom", "You are right, I hope it contains information about it.", 3, "foundSmallPuzzle");

        Subtitle solvedSmallPuzzle1 = new Subtitle("Tom", "Yes!", 3, "solvedSmallPuzzle");
        Subtitle solvedSmallPuzzle2 = new Subtitle("Garry", "Nicely done. Let's continue.", 3, "solvedSmallPuzzle");

        Subtitle foundBigPuzzle1 = new Subtitle("Tom", "No way?! It's huge!", 1, "foundBigPuzzle");
        Subtitle foundBigPuzzle2 = new Subtitle("Garry", "I can guess this is where your challenge begins.", 2, "foundBigPuzzle");
        Subtitle foundBigPuzzle3 = new Subtitle("Tom", "Look, there are more pages on the floor.", 2, "foundBigPuzzle");

        Subtitle storyTime1 = new Subtitle("Tom", "The story about Lucidious.", 2, "storyTime");
        Subtitle storyTime2 = new Subtitle("Tom", "5000 years ago, a boy was born in a witch family. His name was Lucidious. He had gifts, that no one could explain, not even the witches, not even himself.", 2, "storyTime");
        Subtitle storyTime3 = new Subtitle("Tom", "While the people of the village were unknown of those gifts, his family was the one that was keeping this a secret. Years passed and the boy fell in love with a girl named Eve.", 2, "storyTime");
        Subtitle storyTime4 = new Subtitle("Tom", "It was a love at first sight. Eve, however, was already taken by another man, but this didn't stop Lucidious.", 2, "storyTime");
        Subtitle storyTime5 = new Subtitle("Tom", "He used his powers in order to persuade the girl to give up her marriage. She loved Lucidious but her duty as a wife was more important than herself, however, she didn't have a choice.", 2, "storyTime");
        Subtitle storyTime6 = new Subtitle("Tom", "When Eve's father learned about their sin, he confronted his daugther. Frightnened, Eve lied that she didn't love Lucidious and exposed his gifts.", 2, "storyTime");
        Subtitle storyTime7 = new Subtitle("Tom", "Once the people of the village learned this, Lucidious's fate was inevitable. They tied him on a white-oak pile...", 2, "storyTime");
        Subtitle storyTime8 = new Subtitle("Tom", "...and set him on fire. His emotional pain of the beloved's betrayel and the phyiscal pain of getting burned alive made his concisness to create another dimension, another world.", 2, "storyTime");
        Subtitle storyTime9 = new Subtitle("Tom", "This world is known these days by the name 'Hell'. The legend says that no one can avoid Hell and the trial of their regrets, but everyone can be redeemed.", 2, "storyTime");
        Subtitle storyTime10 = new Subtitle("Tom", "Now, Lucidious is known as Lucifer or \"the Devil\" and that he will always be there to punish evil souls. However, there must be balance in nature, therefore, every creature is mortal.", 2, "storyTime");
        Subtitle storyTime11 = new Subtitle("Tom", "Even the Devil himself.When Lucidious was burnt alive, at the time of the creation of a new world, part of his soul binded to the first object it could find.The white - oak pile itself.", 2, "storyTime");
        Subtitle storyTime12 = new Subtitle("Tom", "A few decades later, the witches of the same covern wanted to destroy that dimension and fix their ancestors' mistake, so they found the white-oak pile and created a stake out of it.", 2, "storyTime");
        Subtitle storyTime13 = new Subtitle("Tom", "However, their intention wasn't to fight Lucidious. Their task is passed through generations that one day, when the time is right, someone, who is already in Hell will find the weapon,", 2, "storyTime");
        Subtitle storyTime14 = new Subtitle("Tom", "And have a chance to end the suffering of many souls, including his own, by driving the stake through Lucidious's heart.", 2, "storyTime");








        Subtitle solvedBigPuzzle1 = new Subtitle("Tom", "A staircase appeared. Garry, let's go.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle2 = new Subtitle("Garry", "Unfortuantely, I must stay here. I can't join you further.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle3 = new Subtitle("Tom", "What? No!", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle4 = new Subtitle("Garry", "I suspect you already found the story of the Devil.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle5 = new Subtitle("Tom", "I did, but it's just a legend.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle6 = new Subtitle("Garry", "Every part of that story is true.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle7 = new Subtitle("Tom", "Am I... The person that the witches are waiting for?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle8 = new Subtitle("Garry", "I can't say for sure. But you must be very careful from now on.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle9 = new Subtitle("Tom", "Another reason for you to come with me!", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle10 = new Subtitle("Garry", "Lucifer sent me here to watch over you and make you suffer and believe me, it's like your mind is controlled by him.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle11 = new Subtitle("Garry", "Anyways, somehow I broke the compulsion but I am afraid that once I see him, I will be under his control again.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle12 = new Subtitle("Tom", "How can you know that?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle13 = new Subtitle("Garry", "Because, I can still feel it. I can't help you with your challenges whatever I do. I can't tell you the story of Lucifer that's why I left you the book to read it.", 5, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle14 = new Subtitle("Garry", "I can't even write what your challenges are.", 5, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle15 = new Subtitle("Tom", "Do you know what's up ahead?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle16 = new Subtitle("Garry", "Not entirely certain. Every puzzle represents one of your regrets. Unlocking the door in the hotel room meant that you want to face those challenges.", 5, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle17 = new Subtitle("Garry", "and completing the smaller cube puzzle meant you are ready.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle18 = new Subtitle("Garry", "To understand me better, I need to explain this challenge's regret. Every color represents a dream of yours.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle19 = new Subtitle("Garry", "Fortunately, you only regret not achieveing one dream.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle20 = new Subtitle("Garry", "When you completed the challenge, you were ready to continue your journey.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle21 = new Subtitle("Tom", "How do you know I was ready?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle22 = new Subtitle("Garry", "You continue only if your soul overcomes it. You might not realize it but otherwise you wouldn't be able to continue.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle23 = new Subtitle("Garry", "There are three more challenges, for each regret you have left.", 3, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle24 = new Subtitle("Tom", "What are they?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle25 = new Subtitle("Garry", "(...)", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle26 = new Subtitle("Tom", "Garry, just tell me!", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle27 = new Subtitle("Garry", "Uh... Are you sure you want to know?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle28 = new Subtitle("Tom", "Yes!", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle29 = new Subtitle("Garry", "Alright. You might not face them in this order but the first one is your overthinking.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle30 = new Subtitle("Garry", "You regret that you were overthinking almost all your life, because, it stopped you from simple opportunities.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle31 = new Subtitle("Tom", "Okay, what else?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle32 = new Subtitle("Garry", "Well... I don't know how to say this so I will just say it.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle33 = new Subtitle("Tom", "What? I killed...", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle34 = new Subtitle("Tom", "My wife?", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle35 = new Subtitle("Garry", "Yes, Tom. I am so sorry.", 2, "solvedBigPuzzle");
        Subtitle solvedBigPuzzle36 = new Subtitle("Tom", "Thank you for telling me. Wish me luck!", 2, "solvedBigPuzzle");



        Subtitle entersLabyrinth = new Subtitle("Tom", "It looks like a labyrinth. Wonder which regret could this be?", 2, "entersLabyrinth");


        Subtitle foundStake = new Subtitle("Tom", "This must be the stake that kills the Devil.", 2, "foundStake");


        Subtitle mapFound1 = new Subtitle("Tom", "It's a map. The yellow dot must be my location...", 2, "mapFound");
        Subtitle mapFound2 = new Subtitle("Tom", "Wonder what could the red dot be?", 2, "stakeMapFound");

        Subtitle exitFromlabyrinth = new Subtitle("Tom", "There's the exit!", 2, "exitFromlabyrinth");



        Subtitle suicideTwoStaircases = new Subtitle("Tom", "Two staircases... I wonder, which one should I take?", 2, "twoStaircases");



        Subtitle suicideLoop1 = new Subtitle("Tom", "What? I came back from where I started?", 2, "suicideLoop1");
        Subtitle suicideLoop2 = new Subtitle("Tom", "What's happening?", 2, "suicideLoop2");
        Subtitle suicideLoop3 = new Subtitle("Tom", "It's the same place everytime.", 2, "suicideLoop3");
        Subtitle suicideLoop41 = new Subtitle("Tom", "Alright, Tom. Think... I didn't kill anyone, nor I killed myself, so the labyrinth must be the overthinking part.", 2, "suicideLoop4");
        Subtitle suicideLoop42 = new Subtitle("Tom", "I don't see a single soul here, therefore, only one regret is left. The question is...", 2, "suicideLoop4");
        Subtitle suicideLoop43 = new Subtitle("Tom", "how can I kill myself?", 2, "suicideLoop4");


        Subtitle final1 = new Subtitle("Unknown", "Hello, Tom!", 2, "final");
        Subtitle final2 = new Subtitle("Tom", "A monster?!?", 2, "final");
        Subtitle final3 = new Subtitle("Tom", "... The Devil", 2, "final");
        Subtitle final4 = new Subtitle("Lucidious", "That's right, congratualitions on reaching that far.", 2, "final");
        Subtitle final5 = new Subtitle("Lucidious", "Now, I will send you where you started.", 2, "final");
        Subtitle final6 = new Subtitle("Tom", "No!", 2, "final");
        Subtitle final7 = new Subtitle("Tom", "I want my freedom, I want to find peace!", 2, "final");
        Subtitle final8 = new Subtitle("Tom", "(Laughing) Peace?", 2, "final");
        Subtitle final9 = new Subtitle("Tom", "You don't deserve peace and now I will enjoy your pain and suffering.", 2, "final");


        Subtitle devilDie = new Subtitle("Lucidious", "No! What have you done?!", 2, "devilDie");



        listOfSubtitles.Add(firstDialogue1);
        listOfSubtitles.Add(firstDialogue2);
        listOfSubtitles.Add(firstDialogue3);
        listOfSubtitles.Add(firstDialogue4);
        listOfSubtitles.Add(firstDialogue5);
        listOfSubtitles.Add(firstDialogue6);
        listOfSubtitles.Add(firstDialogue7);
        listOfSubtitles.Add(firstDialogue8);
        listOfSubtitles.Add(firstDialogue9);
        listOfSubtitles.Add(firstDialogue10);
        listOfSubtitles.Add(firstDialogue11);
        listOfSubtitles.Add(firstDialogue12);
        listOfSubtitles.Add(firstDialogue13);
        listOfSubtitles.Add(firstDialogue14);
        listOfSubtitles.Add(firstDialogue15);



        listOfSubtitles.Add(secondDialogue1);
        listOfSubtitles.Add(secondDialogue2);
        listOfSubtitles.Add(secondDialogue3);
        listOfSubtitles.Add(secondDialogue4);




        listOfSubtitles.Add(thirdDialogue1);
        listOfSubtitles.Add(thirdDialogue2);
        listOfSubtitles.Add(thirdDialogue3);
        listOfSubtitles.Add(thirdDialogue4);

        listOfSubtitles.Add(roomEscapeDialogue1);
        listOfSubtitles.Add(roomEscapeDialogue2);
        listOfSubtitles.Add(roomEscapeDialogue3);
        listOfSubtitles.Add(roomEscapeDialogue4);
        listOfSubtitles.Add(roomEscapeDialogue5);

        listOfSubtitles.Add(foundSmallPuzzle1);
        listOfSubtitles.Add(foundSmallPuzzle2);
        listOfSubtitles.Add(foundSmallPuzzle3);
        
        listOfSubtitles.Add(solvedSmallPuzzle1);
        listOfSubtitles.Add(solvedSmallPuzzle2);

        listOfSubtitles.Add(foundBigPuzzle1);
        listOfSubtitles.Add(foundBigPuzzle2);
        listOfSubtitles.Add(foundBigPuzzle3);


        listOfSubtitles.Add(solvedBigPuzzle1);
        listOfSubtitles.Add(solvedBigPuzzle2);
        listOfSubtitles.Add(solvedBigPuzzle3);
        listOfSubtitles.Add(solvedBigPuzzle4);
        listOfSubtitles.Add(solvedBigPuzzle4);
        listOfSubtitles.Add(solvedBigPuzzle5);
        listOfSubtitles.Add(solvedBigPuzzle6);
        listOfSubtitles.Add(solvedBigPuzzle7);
        listOfSubtitles.Add(solvedBigPuzzle8);
        listOfSubtitles.Add(solvedBigPuzzle9);
        listOfSubtitles.Add(solvedBigPuzzle10);
        listOfSubtitles.Add(solvedBigPuzzle11);
        listOfSubtitles.Add(solvedBigPuzzle12);
        listOfSubtitles.Add(solvedBigPuzzle13);
        listOfSubtitles.Add(solvedBigPuzzle14);
        listOfSubtitles.Add(solvedBigPuzzle15);
        listOfSubtitles.Add(solvedBigPuzzle16);
        listOfSubtitles.Add(solvedBigPuzzle17);
        listOfSubtitles.Add(solvedBigPuzzle18);
        listOfSubtitles.Add(solvedBigPuzzle19);
        listOfSubtitles.Add(solvedBigPuzzle20);
        listOfSubtitles.Add(solvedBigPuzzle21);
        listOfSubtitles.Add(solvedBigPuzzle22);
        listOfSubtitles.Add(solvedBigPuzzle23);
        listOfSubtitles.Add(solvedBigPuzzle24);
        listOfSubtitles.Add(solvedBigPuzzle25);
        listOfSubtitles.Add(solvedBigPuzzle26);
        listOfSubtitles.Add(solvedBigPuzzle27);
        listOfSubtitles.Add(solvedBigPuzzle28);
        listOfSubtitles.Add(solvedBigPuzzle29);
        listOfSubtitles.Add(solvedBigPuzzle30);
        listOfSubtitles.Add(solvedBigPuzzle31);
        listOfSubtitles.Add(solvedBigPuzzle32);
        listOfSubtitles.Add(solvedBigPuzzle33);
        listOfSubtitles.Add(solvedBigPuzzle34);
        listOfSubtitles.Add(solvedBigPuzzle35);
        listOfSubtitles.Add(solvedBigPuzzle36);

        //....

        listOfSubtitles.Add(storyTime1);
        listOfSubtitles.Add(storyTime2);
        listOfSubtitles.Add(storyTime3);
        listOfSubtitles.Add(storyTime4);
        listOfSubtitles.Add(storyTime5);
        listOfSubtitles.Add(storyTime6);
        listOfSubtitles.Add(storyTime7);
        listOfSubtitles.Add(storyTime8);
        listOfSubtitles.Add(storyTime9);
        listOfSubtitles.Add(storyTime10);
        listOfSubtitles.Add(storyTime11);
        listOfSubtitles.Add(storyTime12);
        listOfSubtitles.Add(storyTime13);
        listOfSubtitles.Add(storyTime14);



        listOfSubtitles.Add(final1);
        listOfSubtitles.Add(final2);
        listOfSubtitles.Add(final3);
        listOfSubtitles.Add(final4);
        listOfSubtitles.Add(final5);
        listOfSubtitles.Add(final6);
        listOfSubtitles.Add(final7);
        listOfSubtitles.Add(final8);
        listOfSubtitles.Add(final9);



        listOfSubtitles.Add(suicideTwoStaircases);

        listOfSubtitles.Add(suicideLoop1);
        listOfSubtitles.Add(suicideLoop2);
        listOfSubtitles.Add(suicideLoop3);
        listOfSubtitles.Add(suicideLoop41);
        listOfSubtitles.Add(suicideLoop42);
        listOfSubtitles.Add(suicideLoop43);


        listOfSubtitles.Add(exitFromlabyrinth);


        listOfSubtitles.Add(mapFound1);
        listOfSubtitles.Add(mapFound2);

        listOfSubtitles.Add(foundStake);


        listOfSubtitles.Add(entersLabyrinth);



    }
}
