public class CreateButtonView : ButtonView 
{
    protected override void OnClicked()
    {
        viewModel.CreateUser();
    }
}