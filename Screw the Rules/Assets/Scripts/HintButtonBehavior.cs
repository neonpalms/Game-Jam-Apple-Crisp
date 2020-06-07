using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonBehavior : MonoBehaviour
{
    public Text hintText;

    // Simply stores a reference to the hintText UI text element and sets it
    // to enabled when the ShowHintText() is called (by the button's OnClick event).
    public void ShowHintText()
    {
        if (hintText != null)
            hintText.enabled = true;
        else
            Debug.LogError("Assign the hintText variable, you dope!");
    }
}
