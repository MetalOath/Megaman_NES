using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minXClamp = 0.1f;
    public float maxXClamp = 161.27f;
    public float minYClamp = -0.7f;
    public float maxYClamp = 26.7f;

    void LateUpdate()
    {
        if (GameManager.instance.playerInstance)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;
            cameraTransform.x = GameManager.instance.playerInstance.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);
            cameraTransform.y = GameManager.instance.playerInstance.transform.position.y;
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp);
            transform.position = cameraTransform;
        }
    }
}