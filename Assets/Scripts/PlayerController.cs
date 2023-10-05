using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;  
    [SerializeField] private InputAction playerController;

    [SerializeField] float maxSpeed = 75;
    float turnDirection = 0f;
    [SerializeField] int movespeed = 100;
    void Start()
    {
        playerController.Enable();
    }
    private void OnDisable()
    {
        playerController.Disable();
    }
    private void RotatePlayer(Vector3 rotationVector)
    {
        transform.Rotate(rotationVector * Time.deltaTime * 100);
    }
    private void Accelerate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.right * movespeed * Time.deltaTime);
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turnDirection = playerController.ReadValue<float>();
        // use the possetive value and negative value of the input to turn the car 
        Accelerate();
        // Debug.Log(transform.right * movespeed * Time.deltaTime);
        Vector3 rotationVector = new Vector3(0f, 0f, turnDirection);
        RotatePlayer(rotationVector);
    }
}
