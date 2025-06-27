using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Projectile _prefab = null;
    [SerializeField] protected Transform _muzzle = null;

    public void Shoot()
    {
        var _projectile = Instantiate(_prefab, _muzzle.position, _muzzle.rotation);
        _projectile.Init(_muzzle.right);
    }

    public void Shoot(Vector3 _direction)
    {
        var _projectile = Instantiate(_prefab, _muzzle.position, _muzzle.rotation);
        _projectile.Init(_direction);
    }
}
