using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaHelper : MonoBehaviour
{
    #region Properties

    private RectTransform panel;
    private Rect lastSafeArea = new Rect(0, 0, 0, 0);

    #endregion

    #region Main Functions

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Rect safeArea = Screen.safeArea;

        if (safeArea != lastSafeArea)
        {
            ApplySafeArea(safeArea);
        }
    }

    #endregion

    #region Private Functions

    private void ApplySafeArea(Rect rect)
    {
        lastSafeArea = rect;

        Vector2 anchorMin = rect.position;
        Vector2 anchorMax = rect.position + rect.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
    }

    #endregion
}
