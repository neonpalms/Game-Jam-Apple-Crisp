using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeQuitButtonBehavior : MonoBehaviour
{
    #region Fields
    public GameObject realPlayButton;
    #endregion

    #region Members
    private SpriteRenderer m_MySprite;
    private Animator m_MyAnimator;
    private CircleCollider2D m_MyCollider;

    private Color m_HoverColor = Color.grey;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();
        m_MyAnimator = GetComponent<Animator>();
        m_MyCollider = GetComponent<CircleCollider2D>();
    }

    // Plays the falling and swinging animation when clicked
    private void OnMouseDown()
    {
        m_MyCollider.enabled = false;
        m_MyAnimator.SetTrigger("Swing and Fall");
        realPlayButton.SetActive(true);
    }

    private void OnMouseOver()
    {
        m_MySprite.color = m_HoverColor;
    }

    private void OnMouseExit()
    {
        m_MySprite.color = Color.white;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void AddRigidBody()
    {
        m_MyAnimator.enabled = false;
        gameObject.AddComponent<Rigidbody2D>();
    }

    public void PlaySwingingSound()
    {
        // TODO: Add the swinging sound here.
    }
    #endregion
}
