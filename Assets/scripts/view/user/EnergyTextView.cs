public class EnergyTextView : TextView<UserViewModel>
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("Energy: {0} / {1}", viewModel.Model.Energy, viewModel.Model.MaxEnergy);
    }
}