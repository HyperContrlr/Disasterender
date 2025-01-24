using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class iLikeToMoveItMoveIt : MonoBehaviour
{
    public Rigidbody rb;
    public float buildUp;
    public float maxSpeed;

    public CharacterController controller;
    public Transform cam;
    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = (new Vector3(horizontal, 0f, vertical).normalized);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //while (direction.magnitude <= maxSpeed)
            //{
            //    speed += buildUp;
            //}
            //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.z);
        }
    }
}
