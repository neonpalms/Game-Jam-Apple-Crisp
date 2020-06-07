using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WinListenerBehavior : MonoBehaviour
{
    public static bool winConditionMet = false;

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