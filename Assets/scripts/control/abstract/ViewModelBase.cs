using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class ViewModelBase
{
    public bool ModelChanged;

    protected IModel model;

    protected static Dictionary<string, FieldInfo> modelFieldsDict;

    public Type ModelType { get { return model.GetType(); } }

    public static void Init(Type modelType)
    {
        FieldInfo[] fieldInfos = modelType.GetFields();

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