using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ten_lua_run : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float rotationSpeed = 5f; // Speed of rotation

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Compute the angle in degrees between the object's forward direction and the direction to the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            // Create a target rotation around the Z-axis
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
