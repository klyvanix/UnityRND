using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUIControl : MonoBehaviour
{
    public Image image;

    public ColorPallet ColorPallet;

    public Color startColor;
    public Color hoverColor;
    public Color clickedColor;

    public void OnHover()
    {
        image.color = ColorPallet.ButtonHoverColor;
    }

    public void OnExitHover()
    {
        image.color = ColorPallet.ButtonBaseColor;
    }

    public void OnClicked()
    {
        image.color= ColorPallet.ButtonPressedColor;
    }
}
