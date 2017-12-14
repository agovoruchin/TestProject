public class EnemyNameTextView : TextView<EnemyViewModel> 
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("Name: {0}", viewModel.Model.Name);
    }
}