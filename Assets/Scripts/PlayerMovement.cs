using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //karakterimizin tüm hareket kodlarýný içeren metot
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
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;//kamera ile birlikte dönmesi için
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);//saða sola dönerken keskin deðil yavaþça ve smooth dönmesi için.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;//hareket yönünü belirlemek için.

            
            rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);//velocity'i ayarlamak için
        }
        else
        {//eger direction 0dan buyukse 
            
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {//shifte basýldýgýnda hýzlý kosmak icin.
            speed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3f;
        }

    }
}