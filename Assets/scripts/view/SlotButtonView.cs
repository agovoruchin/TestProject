using UnityEngine;
using UnityEngine.UI;

public class SlotButtonView : MonoBehaviour
{
    private Button button;

    private BaseView<UserViewModel>[] views;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);

        views = transform.parent.GetComponentsInChildren<BaseView<UserViewModel>>();
    }

    protected void OnClicked()
    {
        foreach (var view in views)
        {
            view.SetViewModel(GetInstanceID());
        }
    }
}