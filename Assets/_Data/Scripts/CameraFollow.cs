using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float followSpeed = 10f;

    [SerializeField]
    private float xMin = 0f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPos = target.position + cameraOffset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, float.MinValue, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.deltaTime);

        transform.position = smoothPos;
    }
}
