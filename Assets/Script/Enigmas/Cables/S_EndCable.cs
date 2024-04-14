using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EndCable : MonoBehaviour
{
    [SerializeField]
    private int finishID;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ici");
        if (other.tag == "Cable")
        {
            var cable = other.GetComponent<S_RotateCable>();
            if (cable.cableID == finishID)
            {
                cable.isGood = true;
            }
        }
    }

}
