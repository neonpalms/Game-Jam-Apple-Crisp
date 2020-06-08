using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioPlayerBehavior : MonoBehaviour
{
    #region Enums
    public enum PowerupState { SMALL, BIG };
    #endregion

    #region Fields
    public PowerupState state = PowerupState.SMALL;
    public float movementSpeed = 6f;
    public float maxSpeed = 6f;
    public float jumpForce = 4f;

    public Collider2D groundCollider, headCollider;
    public RuntimeAnimatorController smallAnimations;
    public AnimatorOverrideController bigAnimations;

    [HideInInspector] public bool isGrounded = true;
    #endregion

    #region Members
    KeyCode m_JumpButton = KeyCode.UpArrow;
    KeyCode m_LeftButton = KeyCode.LeftArrow;
    KeyCode m_RightButton = KeyCode.RightArrow;

    SpriteRenderer m_MySprite;
    Rigidbody2D m_MyRigidbody;
    Animator m_MyAnimator;
    BoxCollider2D m_MyCollider;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MySprite = GetComponent<SpriteRenderer>();
        m_MyRigidbody = GetComponent<Rigidbody2D>();
        m_MyAnimator = GetComponent<Animator>();
        m_MyCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_JumpButton) && isGrounded)
            Jump();

        if (Input.GetKey(m_RightButton))
            MoveRight();
        else if (Input.GetKey(m_LeftButton))
            MoveLeft();

        UpdateAnimatorState();
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
        // TODO: Play jump noise
        m_MyRigidbody.AddForce(Vector2.up * (jumpForce * 10), ForceMode2D.Impulse);
    }

    public void PowerUp()
    {
        // TODO: Play powerup noise
        state = PowerupState.BIG;
        m_MyAnimator.runtimeAnimatorController = bigAnimations;

        // Ugly hardcoding for sake of saving time.
        // Basically, set the box collider to the whole sprite and the
        // head collider to the top of sprite.
        m_MyCollider.offset = new Vector2(0, 0);
        m_MyCollider.size = new Vector2(1, 2);
        headCollider.transform.localPosition = new Vector2(0, 1);
    }

    public void PowerDown()
    {
        // TODO: Play power down noise
        state = PowerupState.SMALL;
        m_MyAnimator.runtimeAnimatorController = smallAnimations;

        // Ugly hardcoding for sake of saving time.
        // Basically, set the box collider to half size & the
        // head collider down to half.
        m_MyCollider.offset = new Vector2(0, -0.5f);
        m_MyCollider.size = new Vector2(1, 1);
        headCollider.transform.localPosition = new Vector2(0, 0);
    }

    public void Die()
    {
        // TODO: Play die noise
        m_MyAnimator.SetTrigger("Has Died");
        m_MyRigidbody.simulated = false;
        this.enabled = false;
    }

    private void UpdateAnimatorState()
    {
        m_MyAnimator.SetFloat("Vertical Velocity", m_MyRigidbody.velocity.y);
        m_MyAnimator.SetBool("Is Moving", m_MyRigidbody.velocity.x != 0);
        m_MyAnimator.SetBool("Is Grounded", isGrounded);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
