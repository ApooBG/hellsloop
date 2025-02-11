using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    class Page
    {
        public int pageNr;
        public bool hasPage;

        public Page(int pageNr)
        {
            this.pageNr = pageNr;
            hasPage = false;
        }

        public void FoundPage()
        {
            hasPage = true;
        }
    }



    public bool hasBook;
    bool openedBook;
    int pageNumber;

    List<Page> pages;
    [SerializeField] List<GameObject> allPages;
    [SerializeField] GameObject book;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip clip;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasBook = false;
        openedBook = false;
        pageNumber = 0;
        pages = new List<Page>();

        pages.Add(new Page(0));

        for (int i = 1; i <= allPages.Count*2-1; i++)
        {
            pages.Add(new Page(i));
        }

        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBook)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleBook();
            }

            if (openedBook == true)
            {
                if (Input.GetKeyDown("left"))
                {
                    ChangePage(0);
                }

                if (Input.GetKeyDown("right"))
                {
                    ChangePage(1);
                }
            }
        }
    }

    void ToggleBook()
    {
        openedBook = !openedBook;

        if (openedBook == true)
        {
            book.SetActive(true);
        }

        else
        {
            book.SetActive(false);
        }
    }

    void ChangePage(int direction)
    {
        //0 mean the page before, 1 means next page
        if (direction == 0 && pageNumber == 0)
        {
            pageNumber = 0;
            Refresh();
            return;
        }

        if ((direction == 0 && pageNumber == 1) || (direction == 1 && pageNumber == pages.Count-1))
        {
            pageNumber = 0;
            PlaySound();
        }

        if (direction == 0)
        {
            if (pageNumber == 0)
            {
                Refresh();
                return;
            }


            else if (pages.Find(p => p.pageNr == pageNumber - 2).hasPage == true)
            {
                pageNumber -= 2;
            }

            else
            {
                int newPageNumber = 0;
                foreach (Page p in pages)
                {
                    if (p.pageNr < pageNumber && p.hasPage == true)
                    {
                        newPageNumber = p.pageNr;

                    }

                    if (p.pageNr == pageNumber)
                    {
                        pageNumber = newPageNumber-1;
                        newPageNumber = 0;
                        break;
                    }
                }
            }
        }

        else
        {
            if (pageNumber == pages.Count - 3)
            {
                return;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            else if (pages.Find(p => p.pageNr == pageNumber + 2).hasPage == true)
            {
                pageNumber += 2;
            }

            else
            {
                foreach (Page p in pages)
                {
                    if (p.pageNr > pageNumber + 1 && p.hasPage == true)
                    {
                        pageNumber = p.pageNr;
                        break;
                    }
                }    
            }
        }

        PlaySound();

        Refresh();
    }


    void PlaySound()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Refresh()
    {
        if (openedBook == false)
        {
            book.SetActive(false);
        }

        else
        {
            book.SetActive(true);
        }

        foreach (GameObject page in allPages)
        {
            if (Convert.ToInt32(page.name.Substring(4, page.name.Length - 4)) == pageNumber)
            {
                page.SetActive(true);
            }

            else
            {
                page.SetActive(false);
            }
        }
    }

    public void FoundPage(int pageNumber)
    {
        foreach(Page page in pages)
        {
            if (page.pageNr == pageNumber)
            {
                page.FoundPage();
                Debug.Log(page.pageNr + " is active");
            }
        }
    }

    public void FoundBook()
    {
        hasBook = true;
        Subtitles s = player.GetComponent<Subtitles>();
        s.dialogue = "secondDialogue";
    }
}
