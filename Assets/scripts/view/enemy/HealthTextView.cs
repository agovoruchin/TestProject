public class HealthTextView : TextView<EnemyViewModel> 
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("HP: {0}", viewModel.Model.Health);
    }
}