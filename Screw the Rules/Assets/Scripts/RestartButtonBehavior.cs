using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonBehavior : MonoBehaviour
{
    // Also includes a runtime listener for the 'R' key!
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartScene();
    }

    // The public method that the buttons OnClick event can sub to.
    // Simply reloads the current scene immediately.
    public void RestartScene()
    {
#if UNITY_EDITOR
        Debug.Log("Restarted scene.");
#endif
        Application.LoadLevel(Application.loadedLevel);
    }
}
