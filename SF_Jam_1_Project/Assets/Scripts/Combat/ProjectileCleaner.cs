using System.Collections;
using UnityEngine;

public class ProjectileCleaner : MonoBehaviour
{
    [SerializeField] Renderer _renderer = null;

    [Header("// READONLY")]
    [SerializeField] Confiner _confiner = null;
    [SerializeField] bool _isDestroying = false;

    private void Start()
    {
        _confiner = FindFirstObjectByType<Confiner>();
    }

    private void Update()
    {
        if (_isDestroying) return;

        if (!_confiner.Contains(transform.position) && !_renderer.isVisible)
        {
            StartCoroutine(Destroy_Routine());
        }
    }

    private IEnumerator Destroy_Routine()
    {
        _isDestroying = true;
        var _t = Random.Range(2f, 4f);
        yield return new WaitForSeconds(_t);
        Destroy(gameObject);
    }
}
