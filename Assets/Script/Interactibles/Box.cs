using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interractibles
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void Interraction()
    {
        base.Interraction();
        Debug.Log("caisse");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Interraction();
        }
    }


}
