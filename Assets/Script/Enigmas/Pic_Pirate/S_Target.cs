using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class S_Target : MonoBehaviour
{



    private bool touched = false;
    private bool turned = false;
    private int incr = 0;
    public float speedRota = 1f;




    //private Quaternion test = transform.rotation;


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



            StartCoroutine(startRota());



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


    private IEnumerator startRota()
    {
        while (incr <= 180)
        {
            yield return new WaitForEndOfFrame();
            incr++;
            this.transform.Rotate(1, 0, 0);

        }


    }

}
