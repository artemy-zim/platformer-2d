using System.Collections;
using TMPro;
using UnityEngine;

public class CooldownCounterView : MonoBehaviour
{
    [SerializeField] private CooldownCounter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _renderCoroutine;

    private void Awake()
    {
        _text.enabled = false;
    }

    private void OnEnable()
    {
        _counter.OnCooldownCounterStarted += CooldownCounterStartEventHandler;
    }

    private void OnDisable()
    {
        _counter.OnCooldownCounterStarted -= CooldownCounterStartEventHandler;
    }

    private void CooldownCounterStartEventHandler()
    {
        _text.enabled = true;

        if (_renderCoroutine != null)
            StopCoroutine(_renderCoroutine);

        _renderCoroutine = StartCoroutine(OnRenderCoroutine());
    }

    private IEnumerator OnRenderCoroutine()
    {
        while (_counter.CooldownLeft > 0)
        {
            _text.text = $"{_counter.CooldownLeft:0.0}";

            yield return null;
        }

        _text.enabled = false;
    }
}
