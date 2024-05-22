using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewBarSmooth : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField, Min(0)] private float _duration;

    private Coroutine _healthUpdateCoroutine;

    protected override void UpdateView()
    {
        if (_healthUpdateCoroutine != null)
            StopCoroutine(_healthUpdateCoroutine);

        _healthUpdateCoroutine = StartCoroutine(OnHealthUpdate());
    }

    private IEnumerator OnHealthUpdate()
    {
        float value = Health.CurrentHealth / MaxHealth;
        float epsilon = 0.001f;

        while (Mathf.Abs(_slider.normalizedValue - value) > epsilon)
        {
            _slider.normalizedValue = Mathf.MoveTowards(_slider.normalizedValue, value, Time.deltaTime / _duration);

            yield return null;
        }

        _slider.normalizedValue = value;
    }
}
