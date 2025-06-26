using UnityEngine;

public class SnakeBodySpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public int bodyCount = 5;

    private void Start()
    {
        for (int i = 1; i <= bodyCount; i++)
        {
            GameObject part = Instantiate(bodyPartPrefab);
            part.GetComponent<SnakeBodyPart>().Init(transform.GetComponent<SnakeHead>(), i * 10);
            //part.GetComponent<SnakeBodyPart>().head = this.transform;
            //part.GetComponent<SnakeBodyPart>().index = i * 10; // 10 steps apart
            //part.GetComponent<SnakeBodyPart>().headScript = transform.GetComponent<SnakeHead>();
        }
    }
}
