using UnityEngine;
using UnityEngine.UI;

public class LevelNumberFadeIn : MonoBehaviour
{
    // Simple, one-off script for the title screen to 
    // fade the Level number text in, to tip the player off
    // that they just finished the first puzzle.

    #region Members
    private Text m_MyText;
    #endregion

    private void Awake()
    {
        m_MyText = GetComponent<Text>();
    }

    public void FadeIn()
    {
        LeanTween.alphaText(GetComponent<RectTransform>(), 1.0f, 0.5f);
    }
}
