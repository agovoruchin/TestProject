using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class ViewModelBase<M> where M : IModel, new()
{
    public bool ModelChanged;

    protected M model;

    protected static Dictionary<string, FieldInfo> modelFieldsDict;

    public M Model { get { return model; } }

    public static void Init()
    {
        FieldInfo[] fieldInfos = typeof(M).GetFields();

        modelFieldsDict = new Dictionary<string, FieldInfo>();

        foreach (var fieldInfo in fieldInfos)
        {
            modelFieldsDict.Add(fieldInfo.Name, fieldInfo);
        }
    }

    public void SetModelValue<T>(string fieldName, T value)
    {
        if (modelFieldsDict.ContainsKey(fieldName))
        {
            if (modelFieldsDict[fieldName].FieldType == typeof(T))
            {
                modelFieldsDict[fieldName].SetValue(model, value);
                ModelChanged = true;
            }
        }
    }

    public void Subscribe(SubscriptionHandler.ModelUpdatedDelegate func)
    {
        SubscriptionHandler.Instance.Subscribe(GetHashCode(), func);
    }

    public void Unsubscribe(SubscriptionHandler.ModelUpdatedDelegate func)
    {
        SubscriptionHandler.Instance.Unsubscribe(GetHashCode(), func);
    }

    public void NotifyModelChanged()
    {
        SubscriptionHandler.Instance.NotifyModelChanged(GetHashCode());
    }
}