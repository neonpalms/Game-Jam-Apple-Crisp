using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzleInputFieldBehavior : MonoBehaviour
{
    #region Fields
    // The only reason for this is for those stupid jokes in the CheckAnswer method.
    public Text levelTransitionText;
    #endregion

    #region Members
    private InputField m_InputField;
    #endregion

    #region Methods
    private void Awake()
    {
        m_InputField = GetComponent<InputField>();
    }

    // This method is to be called by the OnEndEdit event called by the
    // InputField UI element!  It checks if the player got the right answer.
    public void CheckAnswer()
    {
        string answer = m_InputField.text;

        switch (answer)
        {
            case "7":
                // TODO: Play buzzer noise
                m_InputField.SetTextWithoutNotify("");
                break;
            case "":
                m_InputField.SetTextWithoutNotify("");
                break;
            case "420":
                levelTransitionText.text = "Blaze it!";
                WinListenerBehavior.winConditionMet = true;
                m_InputField.interactable = false;
                break;
            case "69":
                levelTransitionText.text = "nice.";
                WinListenerBehavior.winConditionMet = true;
                m_InputField.interactable = false;
                break;
            default:
                WinListenerBehavior.winConditionMet = true;
                m_InputField.interactable = false;
                break;
        }
    }
    #endregion
}
