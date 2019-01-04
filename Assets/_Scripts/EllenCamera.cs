using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenCamera : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.05f;

    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;

    public float rotationSpeed = 0.05f;

    // For Initilaization
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position; 
    }

    // LateUpdate is called update methods
    void LateUpdate()
    {
       /* if (rotateAroundPlayer)
        {
            Quaternion cameraTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            _cameraOffset = cameraTurnAngle * _cameraOffset;
        }*/

        Vector3 newPosition = playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtPlayer) //|| rotateAroundPlayer)
            transform.LookAt(playerTransform);
    }
}
