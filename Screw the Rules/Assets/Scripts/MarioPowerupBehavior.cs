using UnityEngine;

public class MarioPowerupBehavior : MonoBehaviour
{
    #region Enums
    enum MoveDir { LEFT, RIGHT };
    #endregion

    #region Fields
    public float movementSpeed = 4f;
    public float maxSpeed = 4f;
    #endregion

    #region Members
    Rigidbody2D m_MyRigidbody;
    MoveDir dir = MoveDir.LEFT;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        switch (dir)
        {
            case MoveDir.LEFT:
                if (m_MyRigidbody.velocity.magnitude < maxSpeed)
                    m_MyRigidbody.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
                break;
            case MoveDir.RIGHT:
                if (m_MyRigidbody.velocity.magnitude < maxSpeed)
                    m_MyRigidbody.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
                break;
        }
    }

    // Powerup the player and destroy self on collision with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.GetComponent<MarioPlayerBehavior>().PowerUp();
            Destroy(gameObject);
        }
    }

    // Make the powerup reflect off the wall if its trigger colliders touch the wall.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dir == MoveDir.LEFT)
            dir = MoveDir.RIGHT;
        else if (dir == MoveDir.RIGHT)
            dir = MoveDir.LEFT;
    }
    #endregion
}
