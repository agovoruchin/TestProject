using UnityEngine;
using UnityEngine.UI;

public class SlotButtonView : MonoBehaviour
{
    [SerializeField]
    private int id;

    private Button button;

    private BaseView<UserViewModel>[] views;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    protected void OnClicked()
    {
        ViewModelSubscriptionHandler.Instance.NotifyViewModelChanged(typeof(UserViewModel), id);
    }
}