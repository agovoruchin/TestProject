using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(BaseView<UserViewModel>), true)]
public class CustomViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var view = target as BaseView<UserViewModel>;

        view.Preferences = (ViewModelPreferences)EditorGUILayout.EnumPopup("Preferences", view.Preferences);

        float invisibility = view.Preferences == ViewModelPreferences.SpecificID ? 0f : 1f;

        using (var group = new EditorGUILayout.FadeGroupScope(invisibility))
        {
            if (!group.visible)
            {
                view.ViewModelID = EditorGUILayout.IntField("ViewModel ID", view.ViewModelID);
            }
        }
    }
}