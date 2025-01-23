using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iLikeToMoveItMoveIt : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float accel;
    public Vector3 move;
    public Rigidbody rb;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
        }    
    }
}
