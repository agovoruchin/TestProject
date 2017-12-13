public class LoadButtonView : ButtonView
{
    protected override void OnClicked()
    {
        viewModel.LoadUser();
    }
}