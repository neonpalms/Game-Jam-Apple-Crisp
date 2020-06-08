using UnityEngine;

public class PongPlayerBehavior : MonoBehaviour
{
    #region Fields
    public GameObject laserPrefab;
    public GameObject laserSpawner;

    public float paddleSpeed = 10.0f;
    #endregion

    #region Members
    private BoxCollider2D m_MyCollider;
    private GameObject m_Ball;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyCollider = GetComponent<BoxCollider2D>();
        m_Ball = GameObject.Find("Pong Ball");
    }

    private void Update()
    {
        // Move the player up if press up durr
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Z))
            ShootLaser();
    }

    private void ShootLaser()
    {
        Debug.Log("PEW!");
        GameObject newLaser = Instantiate(laserPrefab, laserSpawner.transform.position, Quaternion.identity);
        newLaser.GetComponent<PongLazerBehavior>().playerCollider = m_MyCollider;
        newLaser.GetComponent<PongLazerBehavior>().ballCollider = m_Ball.GetComponent<BoxCollider2D>();
        // TODO: Play pew noise
    }

    private void LateUpdate()
    {
        // A messy way to keep the player locked inbounds.
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3, 3));
    }
    #endregion
}
