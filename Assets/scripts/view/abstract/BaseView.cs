using UnityEngine;

public enum ViewModelPreferences
{
    Current = 0,
    SpecificID = 1
}

public abstract class BaseView<T> : MonoBehaviour where T : ViewModelBase, new()
{
    [HideInInspector]
    public ViewModelPreferences Preferences;

    [HideInInspector]
    public int ViewModelID;

    protected FactoryBase<T> factory;

    protected T viewModel;

    private void Start()
    {
        factory = GetComponentInParent<FactoryBase<T>>();

        viewModel = factory.Get(Preferences == ViewModelPreferences.Current ? 0 : ViewModelID);

        if (Preferences == ViewModelPreferences.Current)
            ViewModelSubscriptionHandler.Instance.Subscribe(typeof(T), OnViewModelChanged);

        Init();
    }

    private void OnDestroy()
    {
        if (Preferences == ViewModelPreferences.Current)
            ViewModelSubscriptionHandler.Instance.Unsubscribe(typeof(T), OnViewModelChanged);

        DoDestroy();
    }

    public void SetViewModel(int id)
    {
        viewModel = factory.Get(id);
        RemoveSubscriptions();
        Init();
        viewModel.NotifyModelChanged();
    }

    protected virtual void Init()
    {
    }

    protected virtual void DoDestroy()
    {
    }

    protected virtual void RemoveSubscriptions()
    {
    }

    private void OnViewModelChanged(int id)
    {
        SetViewModel(id);
    }
}