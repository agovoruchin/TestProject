using UnityEngine.UI;

public abstract class TextView : BaseView
{
    protected Text text;

    protected override void Init()
    {
        text = GetComponent<Text>();

        viewModel.Subscribe(OnUserModelUpdated);
    }

    protected virtual void OnDestroy()
    {
        viewModel.Unsubscribe(OnUserModelUpdated);
    }

    protected virtual void OnUserModelUpdated()
    {
    }
}