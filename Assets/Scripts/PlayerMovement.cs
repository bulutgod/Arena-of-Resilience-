using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //karakterimizin t�m hareket kodlar�n� i�eren metot
    public Rigidbody rb; 
    public Transform Cam;
    public float speed = 3f;
    public float turnSmoothTime = 0.1f;
    public Vector3 direction;
    private float turnSmoothVelocity;

    public void Movement()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0, vertical).normalized;

        
        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;//kamera ile birlikte d�nmesi i�in
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);//sa�a sola d�nerken keskin de�il yava��a ve smooth d�nmesi i�in.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;//hareket y�n�n� belirlemek i�in.

            
            rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);//velocity'i ayarlamak i�in
        }
        else
        {//eger direction 0dan buyukse 
            
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {//shifte bas�ld�g�nda h�zl� kosmak icin.
            speed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3f;
        }

    }
}