using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerHeadColliderBehavior : MonoBehaviour
{
    MarioBlockBehavior block;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        block = collision.transform.GetComponent<MarioBlockBehavior>();

        if (block != null)
            block.GetHit();
    }
}
