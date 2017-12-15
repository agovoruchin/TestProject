using System;
using System.Collections.Generic;

public class ViewModelSubscriptionHandler : Singleton<ViewModelSubscriptionHandler>
{
    protected Dictionary<Type, List<Action<int>>> listenerDict;

    public ViewModelSubscriptionHandler()
    {
        listenerDict = new Dictionary<Type, List<Action<int>>>();
    }

    public void Subscribe(Type key, Action<int> callback)
    {
        List<Action<int>> listener;

        if (!listenerDict.ContainsKey(key))
        {
            listener = new List<Action<int>>();
            listenerDict.Add(key, listener);
        }

        listener = listenerDict[key];

        if (!listener.Contains(callback))
            listener.Add(callback);
    }

    public void Unsubscribe(Type key, Action<int> callback)
    {
        if (!listenerDict.ContainsKey(key))
            return;

        List<Action<int>> listener = listenerDict[key];

        if (listener.Contains(callback))
            listener.Remove(callback);
    }

    public void NotifyViewModelChanged(Type key, int id)
    {
        if (!listenerDict.ContainsKey(key))
            return;

        List<Action<int>> listener = listenerDict[key];

        foreach (var func in listener)
        {
            func(id);
        }
    }
}