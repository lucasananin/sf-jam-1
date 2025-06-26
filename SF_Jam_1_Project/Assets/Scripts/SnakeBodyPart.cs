using UnityEngine;

public class SnakeBodyPart : MonoBehaviour
{
    public Transform head;
    public int index; // Which point to follow in the head's trail
    public SnakeHead headScript;

    //private void Awake()
    //{
    //    headScript = head.GetComponent<SnakeHead>();
    //}

    //private void OnEnable()
    //{
    //    headScript.OnMove += Move;
    //}

    private void OnDisable()
    {
        headScript.OnMove -= Move;
    }

    private void LateUpdate()
    {
        Move();
    }

    public void Init(SnakeHead _headScript, int _indexValue)
    {
        headScript = _headScript;
        index = _indexValue;
        head = _headScript.transform;
        //headScript.OnMove += Move;
    }

    private void Move()
    {
        if (headScript.positionHistory.Count > index)
        {
            Vector3 targetPos = headScript.positionHistory[index];
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
        }
    }
}
