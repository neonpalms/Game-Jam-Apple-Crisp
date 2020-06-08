using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PongOpponentBehavior : MonoBehaviour
{
    #region Fields
    public GameObject ballToFollow;
    public GameObject healthBar;
    #endregion

    #region Members
    int health = 3;
    #endregion

    #region Methods
    private void Awake()
    {
        healthBar.GetComponentInChildren<Slider>().maxValue = health;
        healthBar.SetActive(false);
    }

    private void Update()
    {
        // Simply update the position of the paddle to the position of the ball.
        // The clamping is an ugly way to keep it in bounds.
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(ballToFollow.transform.position.y, -3f, 3f));
    }

    public void Hurt()
    {
        if (!healthBar.active)
            healthBar.SetActive(true);
        
        --health;
        healthBar.GetComponentInChildren<Slider>().value = health;

        if (health <= 0)
            Destroy(gameObject);
    }
    #endregion
}
