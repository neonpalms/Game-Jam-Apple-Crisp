using UnityEngine;

public class RealPlayButtonBehavior : MonoBehaviour
{
    #region Members
    private SpriteRenderer m_MySprite;
    private BoxCollider2D m_MyCollider;

    private Color m_HoverColor = Color.grey;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();
        m_MyCollider = GetComponent<BoxCollider2D>();
    }

    // When clicked, the player wins this level!
    private void OnMouseDown()
    {
        WinListenerBehavior.winConditionMet = true;
        m_MyCollider.enabled = false;
        // TODO: Play ding-dong sound!
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
