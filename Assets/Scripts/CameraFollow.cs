﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;

    void FixedUpdate() // Camera that follows the player
    {
        if (player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPosition;

        }
    }
}
