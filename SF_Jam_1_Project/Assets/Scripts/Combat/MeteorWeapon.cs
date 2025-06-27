using UnityEngine;

public class MeteorWeapon : Weapon
{
    [SerializeField] Collider _spawnArea = null;
    [SerializeField] float _fireRate = 1f;

    [Header("// READONLY")]
    [SerializeField] float _nextFire = 0f;

    private void Update()
    {
        _nextFire += Time.deltaTime;

        if (_nextFire > _fireRate)
        {
            _nextFire = 0;
            RandomizeMuzzlePosition();
            Shoot(Vector3.down);
        }
    }

    private void RandomizeMuzzlePosition()
    {
        var _newPos = GeneralMethods.RandomPointInBounds(_spawnArea.bounds);
        _newPos.z = 0;
        _muzzle.position = _newPos;
    }
}
