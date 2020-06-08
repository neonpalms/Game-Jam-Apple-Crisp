using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowPlayerBehavior : MonoBehaviour
{
    // Simply takes a player parameter and follows them within bounds.
    #region Fields
    public Transform playerToFollow;
    public float cameraLeftBound, cameraRightBound;
    #endregion

    #region Members
    const int NUMBER_OF_POINTS = 4;
    #endregion

    #region Methods
    private void LateUpdate()
    {
        // Clamp the coords to the Camera's bounding box
        float newX = Mathf.Clamp(playerToFollow.position.x, cameraLeftBound, cameraRightBound);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    #endregion
}
