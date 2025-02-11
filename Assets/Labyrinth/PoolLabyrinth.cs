using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolLabyrinth : MonoBehaviour
{
    public string currentStage = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        string newName = "";
        GameObject g1 = collision.gameObject;
        try
        {
            if (g1.transform.parent.transform.parent.transform.parent.transform.parent.name.Contains("Stage"))
            {
                newName = g1.transform.parent.transform.parent.transform.parent.transform.parent.name;
            }
        }

        catch
        {
            try
            {
                if (g1.transform.parent.transform.parent.transform.parent.name.Contains("Stage"))
                {
                    newName = g1.transform.parent.transform.parent.transform.parent.transform.parent.name;
                }
            }

            catch
            {
                if (g1.transform.parent.transform.parent.name.Contains("Stage"))
                {
                    newName = g1.transform.parent.transform.parent.transform.parent.transform.parent.name;
                }
            }
        }


        if (newName != currentStage && newName != "")
        {
            currentStage = newName;
            Debug.Log(currentStage);
        }
    }
}
