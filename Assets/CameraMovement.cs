using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float interpSpeed;
    private Vector3 targetPos;

    void LateUpdate()
    {

        targetPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed);

    }
}
