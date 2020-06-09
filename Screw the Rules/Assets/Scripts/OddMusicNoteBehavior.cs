using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OddMusicNoteBehavior : MonoBehaviour
{

    #region Fields
    public UnityEvent onClick;
    #endregion

    #region Methods
    private void Awake()
    {
        if (onClick == null)
            onClick = new UnityEvent();
    }

    private void OnMouseDown()
    {
        onClick.Invoke(); ;
    }

    public void EnableNextPuzzle(GameObject nextPuzzle)
    {
        SoundEffectsManagerBehavior.instance.PlayWinNoise();
        nextPuzzle.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

    public void Win()
    {
        WinListenerBehavior.winConditionMet = true;
    }
    #endregion
}
