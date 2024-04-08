using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ICollectible_Gun : S_Interractible_Collectible
{


    public GameObject bullet;
    private GameObject myBullet;
    public Camera cam;
    private Vector3 directionToShoot;
    private Rigidbody rb;
    public int shootVar = 1000;
    public float offsetX = 0f, offsetY = 0f, offsetZ = 0f;
    public S_PlayerManager playerManager;





    public override void Interraction()
    {
        directionToShoot = cam.transform.forward;

        myBullet = Instantiate(bullet, new Vector3(this.transform.position.x + offsetX, this.transform.position.y + offsetY, this.transform.position.z + offsetZ), this.transform.rotation);
        rb = myBullet.GetComponent<Rigidbody>();
        rb.AddForce(directionToShoot * shootVar);
        StartCoroutine(killBullet(myBullet));
    }



    private IEnumerator killBullet(GameObject myBull)
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(myBull);
    }
}
