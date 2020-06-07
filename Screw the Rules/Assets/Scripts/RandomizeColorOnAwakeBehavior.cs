using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomizeColorOnAwakeBehavior : MonoBehaviour
{
    #region Fields
    [Range(0.0f, 1.0f)] public float alpha = 1.0f;
    [Range(0.0f, 1.0f)] public float value = 1.0f;
    #endregion

    #region Members
    SpriteRenderer m_MySprite;
    #endregion

    // When attached to something with a SpriteRenderer, simply randomizes the
    // color field within certain constraints.
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();

        Color randomizedColor = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, value, value);
        randomizedColor.a = alpha;

        m_MySprite.color = randomizedColor;
    }
}
