using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SubtitleTextBehavior : MonoBehaviour
{
    #region Fields
    public List<Font> randomFonts;
    #endregion

    #region Members
    private Text m_MyText;

    private string[] m_Subtitles =
    {
        "You Can’t Tell Me What to Do!",
        "Just Wanna Play Video Games!",
        "You're Not Even My Real Dad!",
        "You Can't Make Me!",
        "Is Anybody Even Reading This?",
        "I Do What I Want!",
        "I Have Money."
    };
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

    public void ChangeMessage()
    {
        int index = Random.Range(0, m_Subtitles.Length);
        m_MyText.text = m_Subtitles[index];
    }
    #endregion
}
