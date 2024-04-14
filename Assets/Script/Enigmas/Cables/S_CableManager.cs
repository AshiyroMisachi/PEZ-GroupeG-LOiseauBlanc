using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CableManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<S_RotateCable> RotateCables;
    private bool enigmaCompleted = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < RotateCables.Count; ++i)
        {
            if (!RotateCables[i].isGood)
            {
                return;
            }

        }
        enigmaCompleted=true;
        
    }


    public bool getEnigmaCompleted() { return enigmaCompleted; }

}
