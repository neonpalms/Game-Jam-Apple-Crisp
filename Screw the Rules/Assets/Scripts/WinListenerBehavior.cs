using UnityEngine;
using UnityEngine.UI;

public class WinListenerBehavior : MonoBehaviour
{
    #region Static Fields
    public static bool winConditionMet;
    #endregion

    #region Fields
    public LevelSwipeInTransitionBehavior transition;
    public GameObject restartButton;
    #endregion

    // Every time an instance of this object is created, which should be every scene,
    // then set the winCondition to false.  Special priority is added to this script in
    // the Unity editor.
    private void Awake()
    {
        winConditionMet = false;
    }

    void Update()
    {
        if (winConditionMet)
            WinLevel();
    }

    private void WinLevel()
    {
        transition.winConditionMet = true;
        winConditionMet = false;
        
        if (restartButton != null)
        {
            restartButton.GetComponent<Button>().interactable = false;
            restartButton.GetComponent<RestartButtonBehavior>().enabled = false;
        }
    }
}