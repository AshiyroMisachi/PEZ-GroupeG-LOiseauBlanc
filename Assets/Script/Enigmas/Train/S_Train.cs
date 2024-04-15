using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class S_Train : Manager
{
    public SplineAnimate splineTrain,splineWagon1,splineWagon2;
    public int currentPos = 0;
    public List<GameObject> stopPoints = new List<GameObject>();
    public List<bool> stopPointFree = new List<bool>();
   // private bool finsih;


    void Start()
    {

        splineTrain.Pause();
        splineWagon1.Pause();
        splineWagon2.Pause();

        for(int i = 0;i < stopPoints.Count; i++)
        {
            stopPointFree.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {



        if (stopPointFree[currentPos])
        {
            currentPos++;

        }


        



        
    }


    public void isEnigmaCompleted(int id)
    {
        stopPointFree[id] = true;
        return;
    }

}
