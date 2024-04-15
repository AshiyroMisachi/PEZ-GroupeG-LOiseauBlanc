using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TargetManager : MonoBehaviour
{

    public List<S_Target> targets = new List<S_Target>();
    public S_ManagerManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targets.Count; ++i)
        {
            if (!targets[i].turned)
            {
                return;
            }

        }
        S_ManagerManager.GetManager<S_Train>().isEnigmaCompleted(0);
    }

 
}
