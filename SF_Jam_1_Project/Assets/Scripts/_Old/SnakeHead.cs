using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move forward
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * transform.forward);

        // Rotate with A/D
        float h = Input.GetAxis("Horizontal");
        Quaternion deltaRotation = Quaternion.Euler(0f, h * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
