using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RandomizeAnimationControllerOnAwakeBehavior : MonoBehaviour
{
    // This script simply takes a list of animation controllers and
    // applies it on Awake() to this object.  Used initally for the
    // title screen, so you don't see the same animation every time
    // you boot up the game.

    #region Fields
    public List<AnimatorOverrideController> controllers;
    #endregion

    #region Members
    private Animator m_MyAnimator;
    #endregion

    private void Awake()
    {
        if (controllers.Count == 0)
        {
            Debug.LogError("Fill this list up with animator override controllers, you idiot.");
            return;
        }

        m_MyAnimator = GetComponent<Animator>();
        int index = Random.Range(0, controllers.Count);
        m_MyAnimator.runtimeAnimatorController = controllers[index];
    }

}
