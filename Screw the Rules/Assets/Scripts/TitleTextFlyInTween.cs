using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTextFlyInTween : MonoBehaviour
{
    #region Fields
    public float flyInDuration;
    #endregion

    private void Start()
    {
        LeanTween.moveLocalX(gameObject, 0, flyInDuration);
    }
}
