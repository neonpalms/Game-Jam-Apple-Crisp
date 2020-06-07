using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonBehavior : MonoBehaviour
{
    // This button is also constantly listening for the Escape key
    // to be pressed so it can quit the game.
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    // The public method for the button's OnClick event to subscribe to
    // Quits the game, duh.
    public void QuitGame()
    {
        Application.Quit();
    }
}
