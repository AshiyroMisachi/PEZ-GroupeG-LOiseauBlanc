using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_CheckStation : MonoBehaviour
{
    public S_Train trainManager;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        trainManager = S_ManagerManager.GetManager<S_Train>();
        trainManager.splineTrain.Pause();
        trainManager.splineWagon1.Pause();
        trainManager.splineWagon2.Pause();
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Train")
        {
            if(trainManager.currentPos<=id)
            {
                trainManager.splineTrain.Pause();
                trainManager.splineWagon1.Pause();
                trainManager.splineWagon2.Pause();
            }


        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Train")
        {
            if (trainManager.currentPos > id)
            {

                trainManager.splineTrain.Play();
                trainManager.splineWagon1.Play();
                trainManager.splineWagon2.Play();
            }


        }
    }


}
