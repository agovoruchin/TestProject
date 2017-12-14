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

    public void SpawnOrc()
    {
        model = new EnemyModel()
        {
            Name = "Orc",
            Health = 150,
            AttackPower = 14
        };

        NotifyModelChanged();
    }

    public void TakeDamage(int amount)
    {
        Model.Health -= amount;

        if (Model.Health < 0)
            Model.Health = 0;

        ModelChanged = true;
    }
}