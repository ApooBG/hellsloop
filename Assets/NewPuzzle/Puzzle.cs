using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    List<int> listOfCubes = new List<int>();
    List<GameObject> children = new List<GameObject>();
    public List<Transform> listOfPositions = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        GetCubePuzzle();
        listOfCubes.Sort();
        AddPositions();
    }


    void AddPositions()
    {
        foreach (int i in listOfCubes)
        {
            GameObject cube = children.First(o => o.name == "Cube" + i);
            listOfPositions.Add(cube.transform);
        }
    }

    void GetCubePuzzle()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Add them to a list
        foreach (GameObject child in allChildren)
        {
            children.Add(child);
            listOfCubes.Add(Convert.ToInt16(child.name.Remove(0, 4)));
        }
    }

    public bool CheckCollision(Transform t)
    {
        int i = 0;
        children.Clear();
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Add them to a list
        foreach (GameObject child in allChildren)
        {
            if (t.position == child.transform.position)
            {
                return true;
            }
        }

        return false;
    }
}
