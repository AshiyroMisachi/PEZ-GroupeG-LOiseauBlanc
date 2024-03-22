using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Target : MonoBehaviour
{




    private bool touched = false;
    private bool turned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched && !turned)
        {
            turned = true;

            Debug.Log("tourne");
            this.transform.Rotate(180, 0, 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pirate")
        {
            Debug.Log("touche");
            touched = true;
        }
    }
}
