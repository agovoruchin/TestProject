using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;
    private static bool _isApplicationExit = false;

    /// <summary>
    /// get / set Instance
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_isApplicationExit)
                return null;

            if (_instance == null)
                _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<T>();
                singleton.name = "(singleton) " + typeof(T);
                Debug.LogWarning(singleton.name + " created");
            }

            return _instance;
        }
        protected set
        {
            _instance = value;
        }
    }

    /// <summary>
    /// Initialisation
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = this as T;
        _isApplicationExit = false;
    }


    /// <summary>
    /// Kill instance at OnDestroy
    /// </summary>
    protected virtual void OnDestroy()
    {
        _instance = null;
    }

    /// <summary>
    /// Destroy at ApplicationQuit
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        _isApplicationExit = true;
    }
}