using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CableManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<S_RotateCable> RotateCables;
    public List<GameObject> lights;
    public GameObject projo;
    public S_SimonManager simonManager;
    public bool isFinished;

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

        if (!isFinished)
        {
            isFinished = true;
            for (int i = 0; i < lights.Count; ++i)
            {
                lights[i].gameObject.SetActive(true);
            }
            projo.SetActive(false);

            simonManager.ActiveSimon();
        }
    }
}
