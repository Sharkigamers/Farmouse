using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 _cameraOffset;
    [Range(0.01f, 1f)]
    public float smoothFactor = 0.5f;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateAroundPlayer && Input.GetMouseButton(0)) {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPosition = playerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        if (lookAtPlayer || rotateAroundPlayer)
            transform.LookAt(playerTransform);
        transform.eulerAngles = transform.eulerAngles - new Vector3(10f, 0f, 0f);
    }
}
