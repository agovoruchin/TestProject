using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UserViewModel
{
    public bool ModelChanged;

    private UserModel model;

    private static Dictionary<string, FieldInfo> modelFieldsDict;

    public UserModel Model { get { return model; } }

    public static void Init()
    {
        FieldInfo[] fieldInfos = typeof(UserModel).GetFields();

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

    public void CreateUser()
    {
        model = new UserModel()
        {
            Name = "NoName",
            MaxEnergy = 10,
            Energy = 10,
            Gold = 25
        };

        NotifyModelChanged();
    }

    public void LoadUser()
    {
        TextAsset json = Resources.Load<TextAsset>("SavedUser");

        model = JsonUtility.FromJson<UserModel>(json.text);

        NotifyModelChanged();
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