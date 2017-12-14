public class UserNameTextView : TextView<UserViewModel>
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("Name: {0}", viewModel.Model.Name);
    }
}