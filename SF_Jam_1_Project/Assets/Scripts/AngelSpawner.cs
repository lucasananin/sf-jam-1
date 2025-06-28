using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AngelSpawner : MonoBehaviour
{
    [SerializeField] AiHealth _prefab = null;
    [SerializeField] Collider _spawnArea = null;
    [SerializeField] Collider _moveArea = null;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _spawnRate = 1f;
    [SerializeField] int _maxSpawns = 3;

    [Header("// READONLY")]
    [SerializeField] float _nextSpawn = 0f;
    [SerializeField] List<HealthBehaviour> _list = null;

    private void Update()
    {
        if (_list.Count >= _maxSpawns) return;

        _nextSpawn += Time.deltaTime;

        if (_nextSpawn > _spawnRate)
        {
            _nextSpawn = 0;
            var _spawnPosition = GetRandomPosition(_spawnArea.bounds);
            var _instance = Instantiate(_prefab, _spawnPosition, Quaternion.identity);
            var _movePosition = GetRandomPosition(_moveArea.bounds);
            _movePosition.x = _spawnPosition.x;
            var _duration = Vector3.Distance(_spawnPosition, _movePosition) / _moveSpeed;
            _instance.transform.DOMove(_movePosition, _duration);

            _list.Add(_instance);
            _instance.OnDie_Action += RemoveFromList;
        }
    }

    private void RemoveFromList(HealthBehaviour _health)
    {
        _list.Remove(_health);
        _health.OnDie_Action -= RemoveFromList;
    }

    private Vector3 GetRandomPosition(Bounds _bounds)
    {
        var _newPos = GeneralMethods.RandomPointInBounds(_bounds);
        _newPos.z = 0;
        return _newPos;
    }
}
