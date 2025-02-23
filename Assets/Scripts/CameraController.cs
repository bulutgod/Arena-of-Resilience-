using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Oyuncuyu takip etmesi için yazýlan kamera kodu.
    [SerializeField] Transform followTarget;


    private float minVerticalAngle = -7f;
    private float maxVerticalAngle = 45;


    private float rotationY;
    private float rotationX;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
    }
    private void Update()
    {
        rotationX += Input.GetAxis("Mouse Y");
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);


        rotationY += Input.GetAxis("Mouse X");

        var targetRotation = Quaternion.Euler(rotationX,rotationY,0);
        transform.position = followTarget.position - targetRotation * new Vector3(0 , -1 , 5 );
        transform.rotation = targetRotation;
    }
}
