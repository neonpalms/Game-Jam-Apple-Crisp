using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioBlockBehavior : MonoBehaviour
{
    #region Fields
    public GameObject powerup;
    #endregion

    #region Members
    private Animator m_MyAnimator;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyAnimator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        m_MyAnimator.SetTrigger("Block Hit");
    }

    // Simply Removes the transform from the block.
    public void SpawnPowerup()
    {
        Instantiate(powerup, transform.position + Vector3.up, Quaternion.identity);
    }
    #endregion
}
