using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PongOpponentBehavior : MonoBehaviour
{
    #region Fields
    public GameObject ballToFollow;
    #endregion

    #region Methods
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, ballToFollow.transform.position.y);
    }
    #endregion
}
