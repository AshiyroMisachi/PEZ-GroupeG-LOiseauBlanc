using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shoot : MonoBehaviour
{


    public GameObject bullet;
    public Camera cam;
    private Vector3 directionToShoot;
    private Rigidbody rb;
    public int shootVar = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionToShoot = cam.transform.forward;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("tir");
            GameObject myBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
            rb = myBullet.GetComponent<Rigidbody>();
            rb.AddForce(directionToShoot* shootVar);



        }
    }

}
