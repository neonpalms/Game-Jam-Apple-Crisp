using UnityEngine;

public class WinListenerBehavior : MonoBehaviour
{
    public static bool winConditionMet;

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
        winConditionMet = false;
        Debug.Log("Win condition met!");
        // TODO: animated transition to next level!
    }
}