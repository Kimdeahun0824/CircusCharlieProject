using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }

}