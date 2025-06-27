using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody _rb = null;
    [SerializeField] TagCollectionSO _tags = null;
    [SerializeField] float _moveSpeed = 10f;

    public void Init(Vector3 _direction)
    {
        _rb.linearVelocity = _direction.normalized * _moveSpeed;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (!_tags.HasTag(_other.gameObject)) return;

        _other.GetComponent<HealthBehaviour>().Damage();
        Destroy(gameObject);
    }
}
