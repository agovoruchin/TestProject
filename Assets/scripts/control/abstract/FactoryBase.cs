﻿using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase<T> : MonoBehaviour where T : ViewModelBase, new()
{
    protected Dictionary<int, T> viewModelDict;

    protected virtual void Awake()
    {
        viewModelDict = new Dictionary<int, T>();
    }

    public T Get(int id)
    {
        if (!viewModelDict.ContainsKey(id))
        {
            T temp = new T();
            temp.Init();

            viewModelDict.Add(id, temp);
        }

        return viewModelDict[id];
    }

    protected void LateUpdate()
    {
        foreach (var keyValuePair in viewModelDict)
        {
            if (keyValuePair.Value.ModelChanged)
            {
                keyValuePair.Value.ModelChanged = false;
                keyValuePair.Value.NotifyModelChanged();
            }
        }
    }
}