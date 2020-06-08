using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TitleTextBehavior : MonoBehaviour
{
    #region Fields
    public List<Font> randomFonts;
    #endregion

    #region Members
    private Text m_MyText;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyText = GetComponent<Text>();
        ChangeFont();
    }

    // This is the public method for the button event OnClick to invoke.
    // It changes the font to a random font in the list.
    public void ChangeFont()
    {
        if (randomFonts.Count == 0)
        {
            Debug.LogError("Fill this array with fonts so I can have one to pick from, please.");
            return;
        }

        int index = Random.Range(0, randomFonts.Count);
        m_MyText.font = randomFonts[index];

        // TODO: Play 'Pop' sound here!
    }
    #endregion
}
