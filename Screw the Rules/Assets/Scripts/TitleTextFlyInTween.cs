using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTextFlyInTween : MonoBehaviour
{
    #region Fields
    public float flyInDuration;
    public LeanTweenType tweenType;
    #endregion

    private void Start()
    {
        // TODO: Play "whoosh" sound!
        LeanTween.moveLocalX(gameObject, 0, flyInDuration).setEase(tweenType);
    }
}
