using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class S_RotateCable : MonoBehaviour
{


    public Camera cam;
    public Transform startRef;
    private Vector3 initScale, initPos;
    private Quaternion initRotation;
    public bool isGood = false;
    private float zCameraOffset;
    [SerializeField]
    public int cableID;



    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        initRotation = transform.rotation;
        initPos = transform.position;
        
        zCameraOffset = cam.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnMouseDrag()
    {

        if (!isGood)
        {

           // Debug.Log(startRef.localPosition);

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCameraOffset);
            Vector3 mouseOnScreen = cam.ScreenToWorldPoint(mousePos);


            //float scaleX = Vector3.Distance(new Vector3(startRef.position.x, 0,0), new Vector3(mouseOnScreen.x,0, 0));
            float scaleY = Vector3.Distance(new Vector3(0, startRef.position.y, 0), new Vector3(0, mouseOnScreen.y, 0));
            transform.localScale = new Vector3(initScale.x, scaleY*6f, initScale.z);


            Vector3 middle = new Vector3(startRef.position.x + mouseOnScreen.x, startRef.position.y + mouseOnScreen.y, initPos.z*2f) / 2f;
            transform.position = middle;

            Vector3 rota = (mouseOnScreen - startRef.position);
            transform.up = -rota;
        }

    }


    private void OnMouseUp()
    {
        if (!isGood)
        {
            transform.localScale = initScale;
            transform.localRotation = initRotation;
            transform.position = initPos;
        }

    }


}
