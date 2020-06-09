using UnityEngine;

public class PhysicsBallBehavior : MonoBehaviour
{
    #region Members
    CompositeCollider2D m_MyCollider;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyCollider = GetComponent<CompositeCollider2D>();

        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Physics Ball"))
        {
            Physics2D.IgnoreCollision(m_MyCollider, ball.GetComponent<Collider2D>());
        }
    }
    #endregion
}
