using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioWinFlagBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
            WinLevel();
    }

    private void WinLevel()
    {
        GameObject.Find("Player").SetActive(false);
        WinListenerBehavior.winConditionMet = true;
    }
}
