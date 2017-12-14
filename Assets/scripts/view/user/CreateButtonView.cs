public class CreateButtonView : ButtonView<UserViewModel>
{
    protected override void OnClicked()
    {
        viewModel.CreateUser();
    }
}