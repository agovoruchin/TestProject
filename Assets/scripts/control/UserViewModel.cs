using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UserViewModel : ViewModelBase<UserModel>
{
    public void CreateUser()
    {
        model = new UserModel()
        {
            Name = "NoName",
            MaxEnergy = 10,
            Energy = 10,
            Gold = 25
        };

        NotifyModelChanged();
    }

    public void LoadUser()
    {
        TextAsset json = Resources.Load<TextAsset>("SavedUser");

        model = JsonUtility.FromJson<UserModel>(json.text);

        NotifyModelChanged();
    }
}