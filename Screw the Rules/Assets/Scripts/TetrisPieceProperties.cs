using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieceProperties : MonoBehaviour
{
    #region Enums
    public enum PieceType { Z, Z_FLIPPED, L, L_FLIPPED, O, I }
    #endregion

    #region Fields
    public PieceType type;
    #endregion
}
