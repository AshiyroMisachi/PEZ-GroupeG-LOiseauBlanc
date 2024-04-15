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
    public Animator animator;
    public bool open = false;


    void Start()
    {

        splineTrain.Play();
        splineWagon1.Play();
        splineWagon2.Play();

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



        if (currentPos >= 5 && !open)
        {
            open = true;
            animator.SetTrigger("Open");

        }


        
    }


    public void isEnigmaCompleted(int id)
    {
        stopPointFree[id] = true;
        return;
    }

}
