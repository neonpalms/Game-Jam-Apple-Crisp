using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPipeBehavior : MonoBehaviour
{
    #region Members
    Animator m_MyAnimator;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
            m_MyAnimator.SetBool("Player In Vicinity", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
            m_MyAnimator.SetBool("Player In Vicinity", false);
    }
    #endregion
}
