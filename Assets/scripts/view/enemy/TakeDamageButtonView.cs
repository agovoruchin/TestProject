public class TakeDamageButtonView : ButtonView<EnemyViewModel> 
{
    protected override void OnClicked()
    {
        viewModel.TakeDamage(viewModel.Model.AttackPower);
    }
}