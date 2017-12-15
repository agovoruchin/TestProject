using System;
using UnityEngine;

public class AbstractFactory : MonoSingleton<AbstractFactory> 
{
    public T GetViewModel<T>(int id) where T : ViewModelBase, new()
    {
        Type concreteFactoryType = Type.GetType(typeof(T).Name + "Factory");

        // create factory via Activator by using the concreteFactoryType
        // return a viewModel build by that factory

        return null;
    }
}