using UnityEngine;

public class Confiner : MonoBehaviour
{
    [SerializeField] Collider _collider = null;

    public bool Contains(Vector3 _position)
    {
        return _collider.bounds.Contains(_position);
    }
}
