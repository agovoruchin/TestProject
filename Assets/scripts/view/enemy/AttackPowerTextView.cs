﻿public class AttackPowerTextView : TextView<EnemyViewModel> 
{
    protected override void OnUserModelUpdated()
    {
        text.text = string.Format("ATK: {0}", viewModel.Model.AttackPower);
    }
}