using UnityEngine;

public abstract class BaseView<T> : MonoBehaviour where T : ViewModelBase, new()
{
    protected FactoryBase<T> factory;

    protected T viewModel;

    private void Start()
    {
        factory = GetComponentInParent<FactoryBase<T>>();

        viewModel = factory.Get(transform.parent.GetInstanceID());

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