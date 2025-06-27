using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public Rigidbody _rb = null;
    public SnakeBodySpawner _spawner = null;

    public event UnityAction OnMove = null;

    void FixedUpdate()
    {
        // Move forward constantly
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        _rb.linearVelocity = transform.right * moveSpeed;

        // Rotate with A/D keys
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, h * turnSpeed * Time.fixedDeltaTime);

        fodase();

        for (int i = 0; i < _spawner._bodyParts.Count; i++)
        {
            _spawner._bodyParts[i].Move();
        }
    }

    public List<Vector3> positionHistory = new List<Vector3>();
    public float gap = 0.5f; // Distance between points
    private float distanceMoved = 0f;

    //void LateUpdate()
    //{
    //    fodase();
    //}

    void fodase()
    {
        if (positionHistory.Count == 0 || Vector3.Distance(transform.position, positionHistory[0]) > gap)
        {
            positionHistory.Insert(0, transform.position);
        }
    }
}
