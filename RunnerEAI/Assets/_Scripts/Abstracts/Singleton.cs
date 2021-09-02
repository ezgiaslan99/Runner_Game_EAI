using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    public static T Instance { get; set; }

    protected void StartSingleton(T entity)
    {
        if (Instance == null)
        {
            Instance = entity;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
