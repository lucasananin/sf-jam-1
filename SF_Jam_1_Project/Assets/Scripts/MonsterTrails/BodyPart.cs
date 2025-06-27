using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] BodyMarker _bodyMarker = null;
    [SerializeField] Rigidbody _rb = null;
    [SerializeField] Collider2D _areaCollider = null;
    [SerializeField] Transform _renderer = null;
    [SerializeField] float _slerpSpeed = 1f;

    public BodyMarker BodyMarker { get => _bodyMarker; private set => _bodyMarker = value; }
    public Rigidbody Rb { get => _rb; private set => _rb = value; }
    public Collider2D AreaCollider { get => _areaCollider; private set => _areaCollider = value; }

    public void FlipX()
    {
        FlipX(_rb.linearVelocity.x);
    }

    public void FlipX(float _xVelocity)
    {
        if (_xVelocity > 0)
        {
            var _rotation = Quaternion.Slerp(_renderer.localRotation, Quaternion.identity, _slerpSpeed * Time.deltaTime);
            _renderer.localRotation = _rotation;
        }
        else if (_xVelocity < 0)
        {
            var _rotation = Quaternion.Slerp(_renderer.localRotation, Quaternion.Euler(180, 0, 0), _slerpSpeed * Time.deltaTime);
            _renderer.localRotation = _rotation;
        }
    }
}
