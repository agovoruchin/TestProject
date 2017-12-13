﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase<T, M> : MonoBehaviour where T : ViewModelBase<M>, new() where M : IModel, new()
{
    protected Dictionary<int, T> viewModelDict;

    protected void Awake()
    {
        viewModelDict = new Dictionary<int, T>();
        ViewModelBase<M>.Init();
    }

    public T Get(int id)
    {
        if (!viewModelDict.ContainsKey(id))
        {
            viewModelDict.Add(id, new T());
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