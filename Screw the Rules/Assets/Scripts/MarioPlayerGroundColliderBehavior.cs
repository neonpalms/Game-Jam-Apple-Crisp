using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerGroundColliderBehavior : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        GetComponentInParent<MarioPlayerBehavior>().isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<MarioPlayerBehavior>().isGrounded = false;
    }
}
