public class EnergyTextView : TextView 
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("Energy: {0} / {1}", viewModel.Model.Energy, viewModel.Model.MaxEnergy);
    }
}