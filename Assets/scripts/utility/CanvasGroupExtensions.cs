using UnityEngine;

public static class CanvasGroupExtensions 
{
    public static void Show(this CanvasGroup group)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    public static void Hide(this CanvasGroup group)
    {
        group.alpha = 0f;
        group.blocksRaycasts = false;
        group.interactable = false;
    }
}