using UnityEngine.UI;

public abstract class ButtonView : BaseView 
{
    protected Button button;

    protected override void Init()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    protected virtual void OnClicked()
    {
    }
}