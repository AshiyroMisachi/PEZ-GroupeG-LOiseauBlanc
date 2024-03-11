using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_ManagerManager : MonoBehaviour
{
    private static S_ManagerManager instance;
    private List<Manager> managers;

    public void Awake()
    {
        if (S_ManagerManager.instance == null)
        {
            S_ManagerManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        managers = new List<Manager>();
        managers = GetComponents<Manager>().ToList();
        DontDestroyOnLoad(gameObject);
    }

    public static T GetManager<T>() where T : Manager
    {
        foreach (var manager in instance.managers)
        {
            if (manager.GetType() == typeof(T))
            {
                return (T)manager;
            }
        }
        return null;
    }
}
