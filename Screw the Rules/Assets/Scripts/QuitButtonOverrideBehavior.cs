using UnityEngine;

public class QuitButtonOverrideBehavior : MonoBehaviour
{
    // This button is also constantly listening for the Escape key
    // to be pressed so it can quit the game.
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FakeoutWin();
    }

    // The public method for the button's OnClick event to subscribe to.
    public void FakeoutWin()
    {
        WinListenerBehavior.winConditionMet = true;
        this.enabled = false;
    }
}
