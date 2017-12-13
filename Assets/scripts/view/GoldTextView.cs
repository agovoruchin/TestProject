public class GoldTextView : TextView 
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("Gold: {0}", viewModel.Model.Gold);
    }
}