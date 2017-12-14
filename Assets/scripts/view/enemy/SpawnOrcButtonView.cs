using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrcButtonView : ButtonView<EnemyViewModel> 
{
    protected override void OnClicked()
    {
        viewModel.SpawnOrc();
    }
}