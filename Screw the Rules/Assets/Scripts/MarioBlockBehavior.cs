using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioBlockBehavior : MonoBehaviour
{
    public GameObject powerup;

    // Simply Removes the transform from the block.
    public void SpawnPowerup()
    {
        Instantiate(powerup, transform.position + Vector3.up, Quaternion.identity);
    }
}
