using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisVictorySpotBehavior : MonoBehaviour
{
    // This victory spot demands a certain piece type.
    // It determines if it's satisfied or not based on the
    // logic in the OnTrigger methods!  They're picky.
    #region Fields
    public TetrisPieceProperties.PieceType desiredPieceType;
    public bool isSatisfied;
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TetrisPieceProperties collidedPiece = collision.gameObject.GetComponent<TetrisPieceProperties>();
        if (collidedPiece == null)
            return;
        if (collidedPiece.type == desiredPieceType)
            isSatisfied = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TetrisPieceProperties pieceThatLeft = collision.gameObject.GetComponent<TetrisPieceProperties>();
        if (pieceThatLeft == null)
            return;
        if (pieceThatLeft.type == desiredPieceType)
            isSatisfied = false;
    }
    #endregion
}
