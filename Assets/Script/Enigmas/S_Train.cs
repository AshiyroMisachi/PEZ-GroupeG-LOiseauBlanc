using System.Collections;
using System.Collections.Generic;
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
        for(int i = 0;i < 5; i++)
        {
            stopPointBlocked.Add(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
