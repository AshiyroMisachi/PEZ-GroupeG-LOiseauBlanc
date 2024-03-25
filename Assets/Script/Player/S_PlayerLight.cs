using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerLight : MonoBehaviour
{

    private bool lightOn=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
