using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shoot : MonoBehaviour
{


    public GameObject bullet;
    private GameObject myBullet;
    public Camera cam;
    private Vector3 directionToShoot;
    private Rigidbody rb;
    public int shootVar = 1000;
    public float decalageTirX=1, decalageTirY=0.75f, decalageTirZ=0;
    public bool gunPickedUp = false;
    public S_PlayerManager playerManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager=S_ManagerManager.GetManager<S_PlayerManager>();
       // playerHand = playerManager.GetPlayer().GetComponent< S_PlayerInterract>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(playerHand.GetObjectInHand());

        if (gunPickedUp)
        {
            directionToShoot = cam.transform.forward;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("tir");
                myBullet = Instantiate(bullet, new Vector3(this.transform.position.x + decalageTirX, this.transform.position.y + decalageTirY, this.transform.position.z + decalageTirZ), this.transform.rotation);
                rb = myBullet.GetComponent<Rigidbody>();
                rb.AddForce(directionToShoot * shootVar);
                StartCoroutine(killBullet(myBullet));
            }

        }

    }


    private IEnumerator killBullet(GameObject myBull)
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(myBull);
    }

}
