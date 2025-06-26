using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    public event UnityAction OnMove = null;

    private void Update()
    {
        // Move forward constantly
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);

        // Rotate with A/D keys
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, h * turnSpeed * Time.deltaTime);

        //InsertPosition();

        OnMove?.Invoke();
    }

    public List<Vector3> positionHistory = new();
    public float gap = 0.5f; // Distance between points
    //private float distanceMoved = 0f;

    private void LateUpdate()
    {
        InsertPosition();
    }

    private void InsertPosition()
    {
        if (positionHistory.Count == 0 || Vector3.Distance(transform.position, positionHistory[0]) > gap)
        {
            positionHistory.Insert(0, transform.position);
        }
    }
}
