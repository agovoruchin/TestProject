public class LoadButtonView : ButtonView<UserViewModel>
{
    protected override void OnClicked()
    {
        viewModel.LoadUser();
    }
}