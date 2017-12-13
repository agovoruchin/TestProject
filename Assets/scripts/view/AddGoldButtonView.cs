using UnityEngine;

public class AddGoldButtonView : ButtonView 
{
    [SerializeField]
    private int amount;

    protected override void OnClicked()
    {
        viewModel.SetModelValue("Gold", viewModel.Model.Gold + amount);
    }
}