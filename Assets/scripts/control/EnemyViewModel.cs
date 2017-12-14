using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewModel : ViewModelBase
{
    public EnemyModel Model { get { return (EnemyModel)model; } }

    public EnemyViewModel()
    {
        model = new EnemyModel();
    }
}