using UnityEngine;

public class PlayerWeapon : Weapon
{
    [SerializeField] float _fireRate = 0.1f;

    [Header("// READONLY")]
    [SerializeField] float _nextFire = 0;

    private void Update()
    {
        _nextFire += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _nextFire > _fireRate)
        {
            _nextFire = 0f;
            Shoot();
        }
    }
}
