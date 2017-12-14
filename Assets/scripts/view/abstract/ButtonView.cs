using UnityEngine.UI;

public abstract class ButtonView<T> : BaseView<T> where T: ViewModelBase, new() 
{
    protected Button button;

    protected override void Init()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    protected override void RemoveSubscriptions()
    {
        button.onClick.RemoveListener(OnClicked);
    }

    protected virtual void OnClicked()
    {
    }
}