using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFadeIn : MonoBehaviour
{
    #region Fields
    public float fadeDuration;
    public LeanTweenType tweenType;
    #endregion

    void Start()
    {
        LeanTween.alpha(gameObject, 1, fadeDuration);
        LeanTween.alpha(transform.GetChild(0).gameObject, 1, fadeDuration);
    }
}
