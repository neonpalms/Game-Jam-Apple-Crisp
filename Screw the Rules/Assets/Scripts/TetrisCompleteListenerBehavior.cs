using UnityEngine;

public class TetrisCompleteListenerBehavior : MonoBehaviour
{
    #region Fields
    public TetrisVictorySpotBehavior[] victorySpots = new TetrisVictorySpotBehavior[2];
    #endregion

    #region Members
    bool[] victoryFlags;
    #endregion

    #region Methods
    private void Awake()
    {
        victoryFlags = new bool[victorySpots.Length];
    }

    private void LateUpdate()
    {
        for (int index = 0; index < victorySpots.Length; index++)
        {
            victoryFlags[index] = victorySpots[index].isSatisfied;
        }
    }

    public void CheckBoardForWin()
    {
        bool everyoneIsHappy = true;

        foreach (bool b in victoryFlags)
        {
            if (!b)
                everyoneIsHappy = false;
        }

        if (everyoneIsHappy)
            Win();
    }

    private void Win()
    {
        ClearAllPieces();
        WinListenerBehavior.winConditionMet = true;
    }

    private void ClearAllPieces()
    {
        float animationDuration = 0.5f;

        foreach(GameObject piece in GameObject.FindGameObjectsWithTag("Tetris Piece"))
        {
            LeanTween.scaleY(piece, 0.0f, animationDuration);
        }
    }
    #endregion
}
