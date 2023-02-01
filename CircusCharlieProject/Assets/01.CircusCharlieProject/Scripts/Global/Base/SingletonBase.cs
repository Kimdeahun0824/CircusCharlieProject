using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstance());
    public static T Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    private static T CreateInstance()
    {
        return Activator.CreateInstance(typeof(T), true) as T;
    }
}