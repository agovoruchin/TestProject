using UnityEngine;

public class AddGoldButtonView : ButtonView<UserViewModel>
{
    [SerializeField]
    private int amount;

    protected override void OnClicked()
    {
        viewModel.AddGold(amount);
    }
}