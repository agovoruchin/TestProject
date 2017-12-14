public class SpawnOrcButtonView : ButtonView<EnemyViewModel> 
{
    protected override void OnClicked()
    {
        viewModel.SpawnOrc();
    }
}