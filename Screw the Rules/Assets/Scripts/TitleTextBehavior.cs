using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TitleTextBehavior : MonoBehaviour
{
    #region Fields
    public List<Font> randomFonts;
    public List<Color> randomColors;
    #endregion

    #region Members
    private Text m_MyText;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyText = GetComponent<Text>();
        ChangeFontAndColor();
    }

    // This is the public method for the button event OnClick to invoke.
    // It calls both private methods ChangeFont and ChangeColor.
    // They do exactly what they say to the text component.
    public void ChangeFontAndColor()
    {
        ChangeFont();
        ChangeColor();
    }

    private void ChangeFont()
    {
        if (randomFonts.Count == 0)
        {
            Debug.LogError("Fill this array with fonts so I can have one to pick from, please.");
            return;
        }

        int index = Random.Range(0, randomFonts.Count);
        m_MyText.font = randomFonts[index];
    }

    private void ChangeColor()
    {
        if (randomFonts.Count == 0)
        {
            Debug.LogError("Fill this array with colors so I can have one to pick from, please.");
            return;
        }

        int index = Random.Range(0, randomColors.Count);
        m_MyText.color = randomColors[index];
    }
    #endregion
}
