using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class StaffLineView : View
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image line;

    public void Init(bool isMainLine)
    {
        backgroundImage.enabled = isMainLine;
    }
}