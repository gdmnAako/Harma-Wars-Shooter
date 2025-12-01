using System;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform cameraTransform;

    public float distance = 10f; 
    public float height = 5f;

    public float followSpeed = 10f;
    public float lookSpeed = 10f;

    private void FixedUpdate()
    {
        Vector3 offset = cameraTransform.forward * (-1) * distance + cameraTransform.up * height;
        Vector3 desiredPosition = cameraTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        Quaternion desiredRotation = Quaternion.LookRotation(cameraTransform.position - transform.position);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, lookSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation; 
    }
}
