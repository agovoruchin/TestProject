using System.Collections.Generic;
using UnityEngine;

public class UserViewModelFactory : MonoBehaviour
{
    private Dictionary<int, UserViewModel> viewModelDict;

    private void Awake()
    {
        viewModelDict = new Dictionary<int, UserViewModel>();
        UserViewModel.Init();
    }

    public UserViewModel Get(int id)
    {
        if (!viewModelDict.ContainsKey(id))
        {
            viewModelDict.Add(id, new UserViewModel());
        }

        return viewModelDict[id];
    }

    private void LateUpdate()
    {
        foreach (var keyValuePair in viewModelDict)
        {
            if(keyValuePair.Value.ModelChanged)
            {
                keyValuePair.Value.ModelChanged = false;
                keyValuePair.Value.NotifyModelChanged();
            }
        }
    }
}