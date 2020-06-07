using UnityEngine;

public class WinListenerBehavior : MonoBehaviour
{
    #region Statc Fields
    public static bool winConditionMet;
    #endregion

    #region Fields
    public LevelSwipeInTransitionBehavior transition;
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
    }
}