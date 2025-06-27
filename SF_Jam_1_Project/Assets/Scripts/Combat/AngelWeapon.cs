using System.Collections;
using UnityEngine;

public class AngelWeapon : Weapon
{
    [SerializeField] float _fireRate = 3f;
    [SerializeField] float _chargeTime = 1f;

    [Header("// READONLY")]
    [SerializeField] HealthBehaviour _target = null;
    [SerializeField] float _nextFire = 0f;
    [SerializeField] bool _isShooting = false;

    private void Start()
    {
        _target = FindFirstObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        if (_isShooting) return;

        _nextFire += Time.deltaTime;

        if (_nextFire > _fireRate)
        {
            _nextFire = 0;
            StartCoroutine(Shoot_Routine());
        }
    }

    private IEnumerator Shoot_Routine()
    {
        _isShooting = true;
        yield return new WaitForSeconds(_chargeTime);
        _isShooting = false;
        var _direction = (_target.transform.position - _muzzle.position).normalized;
        Shoot(_direction);
    }
}
