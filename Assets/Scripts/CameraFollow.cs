using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z); // Camera follows the player
    }
}
