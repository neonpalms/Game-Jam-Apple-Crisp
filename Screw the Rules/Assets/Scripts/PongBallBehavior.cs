using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallBehavior : MonoBehaviour
{
    #region Enums
    private enum BallDirection { LEFT = 0, UP_LEFT = 1, DOWN_LEFT = 2, RIGHT = 3, UP_RIGHT = 4, DOWN_RIGHT = 5 };
    #endregion

    #region Fields
    // Holds the ball for a specified number of seconds
    public float delay = 3.0f;

    public float ballSpeed = 10.0f;
    #endregion

    #region Members
    BallDirection m_Dir = BallDirection.RIGHT;
    float m_TimeElapsed = 0.0f;
    #endregion

    #region Methods
    private void Update()
    {
        if (m_TimeElapsed < delay)
        {
            m_TimeElapsed += Time.deltaTime;
            return;
        }

        switch (m_Dir)
        {
            case BallDirection.LEFT:
                transform.Translate(Vector2.left * ballSpeed * Time.deltaTime);
                break;
            case BallDirection.UP_LEFT:
                transform.Translate((Vector2.up + Vector2.left) * ballSpeed * Time.deltaTime);
                break;
            case BallDirection.DOWN_LEFT:
                transform.Translate((Vector2.down + Vector2.left) * ballSpeed * Time.deltaTime);
                break;
            case BallDirection.RIGHT:
                transform.Translate(Vector2.right * ballSpeed * Time.deltaTime);
                break;
            case BallDirection.UP_RIGHT:
                transform.Translate((Vector2.up + Vector2.right) * ballSpeed * Time.deltaTime);
                break;
            case BallDirection.DOWN_RIGHT:
                transform.Translate((Vector2.down + Vector2.right) * ballSpeed * Time.deltaTime);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.name)
        {
            case "Pong Player":
                if (m_Dir == BallDirection.LEFT)
                    m_Dir = (BallDirection)Random.Range(3, 5);
                else if (m_Dir == BallDirection.UP_LEFT)
                    m_Dir = BallDirection.UP_RIGHT;
                else if (m_Dir == BallDirection.DOWN_LEFT)
                    m_Dir = BallDirection.DOWN_RIGHT;
                break;
            case "Pong Opponent":
                if (m_Dir == BallDirection.RIGHT)
                    m_Dir = (BallDirection)Random.Range(0, 2);
                else if (m_Dir == BallDirection.UP_RIGHT)
                    m_Dir = BallDirection.UP_LEFT;
                else if (m_Dir == BallDirection.DOWN_RIGHT)
                    m_Dir = BallDirection.DOWN_LEFT;
                break;
            case "Pong Bounds Top":
                if (m_Dir == BallDirection.UP_LEFT)
                    m_Dir = BallDirection.DOWN_LEFT;
                else if (m_Dir == BallDirection.UP_RIGHT)
                    m_Dir = BallDirection.DOWN_RIGHT;
                break;
            case "Pong Bounds Bottom":
                if (m_Dir == BallDirection.DOWN_LEFT)
                    m_Dir = BallDirection.UP_LEFT;
                else if (m_Dir == BallDirection.DOWN_RIGHT)
                    m_Dir = BallDirection.UP_RIGHT;
                break;
            // Failsafe incase the ball is in a weird spot
            default:
                transform.position = Vector2.zero;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Pong Player Net")
            Reset();
        else if (collision.transform.name == "Pong Opponent Net")
            Win();
    }

    // Extra failsafe incase the ball runs out of camera view
    private void OnBecameInvisible()
    {
        transform.position = Vector2.zero;
    }

    // This is called when the player loses the ball.
    private void Reset()
    {
        SoundEffectsManagerBehavior.instance.PlayLoseNoise();
        transform.position = Vector2.zero;
        m_Dir = BallDirection.RIGHT;
        m_TimeElapsed = 0.0f;
    }

    private void Win()
    {
        WinListenerBehavior.winConditionMet = true;
        Destroy(gameObject);
    }
    #endregion

}
