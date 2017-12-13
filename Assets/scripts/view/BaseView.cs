using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    protected CanvasGroup canvasGroup;

    protected UserViewModel viewModel;

    private UserViewModelFactory factory;

    private void Start()
    {
        factory = GetComponentInParent<UserViewModelFactory>();

        canvasGroup = GetComponentInParent<CanvasGroup>();

        viewModel = factory.Get(canvasGroup.GetInstanceID());

        Init();
    }

    protected virtual void Init()
    {
    }
}