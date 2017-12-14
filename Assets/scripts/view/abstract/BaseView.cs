using UnityEngine;

public enum ViewModelPreferences
{
    Current = 0,
    SpecificID = 1
}

public abstract class BaseView<T> : MonoBehaviour where T : ViewModelBase, new()
{
    [SerializeField]
    private ViewModelPreferences preferences;

    [SerializeField]
    private int viewModelID;

    protected FactoryBase<T> factory;

    protected T viewModel;

    private void Start()
    {
        factory = GetComponentInParent<FactoryBase<T>>();

        viewModel = factory.Get(0);

        Init();
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

    protected virtual void RemoveSubscriptions()
    {
    }
}