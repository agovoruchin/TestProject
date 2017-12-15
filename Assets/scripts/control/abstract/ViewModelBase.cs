using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class ViewModelBase
{
    public bool ModelChanged;

    protected IModel model;

    protected Dictionary<string, FieldInfo> modelFieldsDict;

    public void Init()
    {
        FieldInfo[] fieldInfos = model.GetType().GetFields();

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

    public void Subscribe(Action func)
    {
        ModelSubscriptionHandler.Instance.Subscribe(GetHashCode(), func);
    }

    public void Unsubscribe(Action func)
    {
        ModelSubscriptionHandler.Instance.Unsubscribe(GetHashCode(), func);
    }

    public void NotifyModelChanged()
    {
        ModelSubscriptionHandler.Instance.NotifyModelChanged(GetHashCode());
    }
}