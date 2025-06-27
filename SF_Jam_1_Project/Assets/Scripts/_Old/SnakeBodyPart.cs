using UnityEngine;

public class SnakeBodyPart : MonoBehaviour
{
    public Transform head;
    public int index; // Which point to follow in the head's trail
    public SnakeHead headScript;
    public Rigidbody _rb = null;
    public float moveSpeed = 5f;

    void Start()
    {
        headScript = head.GetComponent<SnakeHead>();
    }

    //void LateUpdate()
    //{
    //    Move();
    //}

    public void Move()
    {
        if (headScript.positionHistory.Count > index)
        {
            Vector3 targetPos = headScript.positionHistory[index];
            //transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);

            var _direction = (targetPos - transform.position).normalized;
            _rb.linearVelocity = _direction * moveSpeed;
        }
    }
}
