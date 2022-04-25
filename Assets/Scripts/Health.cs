using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private const float HealthMinValue = 0f;
    private const float HealthMaxValue = 100f;
    private const float HealthChange = 10f;

    [SerializeField] private UnityEvent _healthChanging;
    
    private float _healthValue;

    private Coroutine _coroutine;

    public float HealthValue => _healthValue;

    private void Start()
    {
        _healthValue = 50f;
    }

    public void TryIncreaseHealth()
    {
        if (_healthValue == HealthMaxValue)
        {
            Debug.Log("Health can't be greater than 100.");
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeHealth(_healthValue + HealthChange > HealthMaxValue ? HealthMaxValue : _healthValue + HealthChange));
        }
    }

    public void TryDecreaseHealth()
    {
        if (_healthValue == HealthMinValue)
        {
            Debug.Log("Health can't be less than 0.");
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeHealth(_healthValue - HealthChange < HealthMinValue ? HealthMinValue : _healthValue - HealthChange));
        }
    }

    private IEnumerator ChangeHealth(float finishValue)
    {
        float changeStep = 10f;

        while (_healthValue != finishValue)
        {
            _healthValue = Mathf.MoveTowards(_healthValue, finishValue, changeStep * Time.deltaTime);

            _healthChanging.Invoke();

            yield return null;
        }
    }
}
