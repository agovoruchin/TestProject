using System.Collections.Generic;

public class SubscriptionHandler : Singleton<SubscriptionHandler>
{
    public delegate void ModelUpdatedDelegate();

    private Dictionary<int, List<ModelUpdatedDelegate>> listenerDict;

    public SubscriptionHandler()
    {
        listenerDict = new Dictionary<int, List<ModelUpdatedDelegate>>();
    }

    public void Subscribe(int id, ModelUpdatedDelegate func)
    {
        List<ModelUpdatedDelegate> listener;

        if (!listenerDict.ContainsKey(id))
        {
            listener = new List<ModelUpdatedDelegate>();
            listenerDict.Add(id, listener);
        }

        listener = listenerDict[id];

        if (!listener.Contains(func))
            listener.Add(func);
    }

    public void Unsubscribe(int id, ModelUpdatedDelegate func)
    {
        if (!listenerDict.ContainsKey(id))
            return;

        List<ModelUpdatedDelegate> listener = listenerDict[id];

        if (listener.Contains(func))
            listener.Remove(func);
    }

    public void NotifyModelChanged(int id)
    {
        if (!listenerDict.ContainsKey(id))
            return;

        List<ModelUpdatedDelegate> listener = listenerDict[id];

        foreach (var func in listener)
        {
            func();
        }
    }
}