using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minXClamp = 0.1f;
    public float maxXClamp = 161.27f;
    public float minYClamp = -0.7f;
    public float maxYClamp = 26.7f;

    void LateUpdate()
    {
        if (player)
        {
            Vector3 cameraTransform;

            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);

            cameraTransform.y = player.transform.position.y;
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp);

            transform.position = cameraTransform;
        }
    }
}
