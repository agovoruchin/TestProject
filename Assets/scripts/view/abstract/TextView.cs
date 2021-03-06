﻿using UnityEngine.UI;

public abstract class TextView<T> : BaseView<T> where T: ViewModelBase, new()
{
    protected Text text;

    protected override void Init()
    {
        text = GetComponent<Text>();

        viewModel.Subscribe(OnUserModelUpdated);
    }

    protected override void RemoveSubscriptions()
    {
        viewModel.Unsubscribe(OnUserModelUpdated);
    }

    protected override void DoDestroy()
    {
        RemoveSubscriptions();
    }

    protected virtual void OnUserModelUpdated()
    {
    }
}