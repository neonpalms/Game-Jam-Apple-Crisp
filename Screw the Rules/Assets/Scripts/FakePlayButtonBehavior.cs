﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakePlayButtonBehavior : MonoBehaviour
{
    #region Members
    private SpriteRenderer m_MySprite;

    private Color m_HoverColor = Color.grey;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();
    }

    // Plays an error sound when this button is clicked.
    private void OnMouseDown()
    {
        Debug.Log("Wrong!");
        // TODO: Play Error sound!
    }

    private void OnMouseOver()
    {
        m_MySprite.color = m_HoverColor;
    }

    private void OnMouseExit()
    {
        m_MySprite.color = Color.white;
    }
    #endregion
}