using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Train : MonoBehaviour
{


    public GameObject train;
    public List<GameObject> stopPoints = new List<GameObject>();
    public List<bool> stopPointReached = new List<bool>();
    public int currentPoint = 0;
    public List<bool> stopPointBlocked = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < stopPoints.Count; i++)
        {
            stopPointReached.Add(false);
        }
        for(int i = 0;i < stopPoints.Count; i++)
        {
            stopPointBlocked.Add(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < stopPoints.Count;i++)
        {
            if (!stopPointBlocked[i]) 
            {

                train.transform.position = Vector3.MoveTowards(train.transform.position, stopPoints[i].transform.position,0.01f);
            }
        }

        
    }


    public void isEnigmaCompleted(int id)
    {
        stopPointBlocked[id] = true;
        return;
    }

}
