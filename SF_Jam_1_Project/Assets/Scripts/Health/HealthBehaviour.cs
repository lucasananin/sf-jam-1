using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] int _value = 1;
    [SerializeField] UnityEvent OnDie = null;

    public event UnityAction<HealthBehaviour> OnDie_Action = null;

    public void Damage()
    {
        if (_value <= 0) return;

        _value--;

        if (_value >= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDie_Action?.Invoke(this);
        OnDie?.Invoke();
    }
}
