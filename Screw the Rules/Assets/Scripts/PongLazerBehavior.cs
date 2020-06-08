using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongLazerBehavior : MonoBehaviour
{
    #region Fields
    public float laserSpeed = 30f;
    public Collider2D playerCollider, ballCollider;
    #endregion

    #region Members
    BoxCollider2D m_MyCollider;
    #endregion

    private void OnEnable()
    {
        m_MyCollider = GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(m_MyCollider, playerCollider);
        Physics2D.IgnoreCollision(m_MyCollider, ballCollider);
    }

    #region Methods
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * laserSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    #endregion
}
