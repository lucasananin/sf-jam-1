using System.Collections.Generic;
using UnityEngine;

public class SnakeBodySpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public int bodyCount = 5;

    public List<SnakeBodyPart> _bodyParts = null;

    void Start()
    {
        for (int i = 1; i <= bodyCount; i++)
        {
            GameObject part = Instantiate(bodyPartPrefab);
            part.GetComponent<SnakeBodyPart>().head = this.transform;
            part.GetComponent<SnakeBodyPart>().index = i * 10; // 10 steps apart
            _bodyParts.Add(part.GetComponent<SnakeBodyPart>());
        }
    }
}
