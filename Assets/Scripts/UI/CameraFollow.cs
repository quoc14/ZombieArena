using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Nhân vật chính
    public float smoothSpeed = 0.125f; // Tốc độ mượt mà
    public Vector3 offset; // Khoảng cách giữa camera và nhân vật

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Vị trí mong muốn của camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Vị trí mượt mà
        transform.position = smoothedPosition; // Cập nhật vị trí camera
    }
}
