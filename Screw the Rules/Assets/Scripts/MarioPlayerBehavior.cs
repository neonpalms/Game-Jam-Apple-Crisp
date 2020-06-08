using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MarioPlayerBehavior : MonoBehaviour
{
    #region Fields
    public float movementSpeed = 6f;
    public float maxSpeed = 6f;
    public float jumpForce = 4f;

    public Collider2D groundCollider, headCollider;

    public bool isGrounded = true;
    #endregion

    #region Members
    KeyCode m_JumpButton = KeyCode.UpArrow;
    KeyCode m_LeftButton = KeyCode.LeftArrow;
    KeyCode m_RightButton = KeyCode.RightArrow;

    SpriteRenderer m_MySprite;
    Rigidbody2D m_MyRigidbody;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();
        m_MyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_JumpButton) && isGrounded)
            Jump();

        if (Input.GetKey(m_RightButton))
            MoveRight();
        else if (Input.GetKey(m_LeftButton))
            MoveLeft();   
    }

    private void MoveRight()
    {
        m_MySprite.flipX = false;

        if (isGrounded)
            if (m_MyRigidbody.velocity.magnitude < maxSpeed)
                m_MyRigidbody.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
        else
            m_MyRigidbody.AddForce(Vector2.right * (movementSpeed / 150), ForceMode2D.Impulse);
    }

    private void MoveLeft()
    {
        m_MySprite.flipX = true;

        if (isGrounded)
            if (m_MyRigidbody.velocity.magnitude < maxSpeed)
                m_MyRigidbody.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
            else
            m_MyRigidbody.AddForce(Vector2.left * (movementSpeed / 150), ForceMode2D.Impulse);
    }

    private void Jump()
    {
        m_MyRigidbody.AddForce(Vector2.up * (jumpForce * 10), ForceMode2D.Impulse);
    }
    #endregion
}
