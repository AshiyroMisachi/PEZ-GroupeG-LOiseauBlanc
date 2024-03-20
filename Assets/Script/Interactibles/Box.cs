using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interractibles
{

    private bool actif = false;
    private GameObject player;
    private Vector3 decalage = new Vector3 (10, 10, 0);
    //ajouter dans interractible l'obligation de rigidbody
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actif)
        {
            this.transform.localPosition = player.transform.localPosition + decalage;
        }
        
    }


    public override void Interraction()
    {
        base.Interraction();
        Debug.Log("caisse");
        actif = true;



    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Interraction();
            player=other.gameObject;
        }
    }


}
