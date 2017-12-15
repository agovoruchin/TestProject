using System;
using System.Collections.Generic;

public class ModelSubscriptionHandler : Singleton<ModelSubscriptionHandler>
{
    protected Dictionary<int, List<Action>> listenerDict;

    public ModelSubscriptionHandler()
    {
        listenerDict = new Dictionary<int, List<Action>>();
    }

    public void Subscribe(int key, Action callback)
    {
        List<Action> listener;

        if (!listenerDict.ContainsKey(key))
        {
            listener = new List<Action>();
            listenerDict.Add(key, listener);
        }

        listener = listenerDict[key];

        if (!listener.Contains(callback))
            listener.Add(callback);
    }

    public void Unsubscribe(int key, Action callback)
    {
        if (!listenerDict.ContainsKey(key))
            return;

        List<Action> listener = listenerDict[key];

        if (listener.Contains(callback))
            listener.Remove(callback);
    }

    public void NotifyModelChanged(int key)
    {
        if (!listenerDict.ContainsKey(key))
            return;

        List<Action> listener = listenerDict[key];

        foreach (var func in listener)
        {
            func();
        }
    }
}