using System.Collections;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private PlayerVampireAttacker _attacker;

    private Coroutine _drawCoroutine;
    private int _vertexAmount;

    private void Awake()
    {
        _lineRenderer.enabled = false;
        _vertexAmount = _lineRenderer.positionCount;
    }

    private void OnEnable()
    {
        _attacker.OnVampireAttackStarted += VampireAttackStartHandler;
        _attacker.OnVampireAttackStopped += VampireAttackStopHandler;
    }
    private void OnDisable()
    {
        _attacker.OnVampireAttackStarted -= VampireAttackStartHandler;
        _attacker.OnVampireAttackStopped -= VampireAttackStopHandler;
    }

    private void VampireAttackStartHandler(float radius)
    {
        _lineRenderer.enabled = true;

        if (_drawCoroutine != null)
            StopCoroutine(_drawCoroutine);

        _drawCoroutine = StartCoroutine(OnDrawCoroutine(radius));
    }

    private void VampireAttackStopHandler()
    {
        _lineRenderer.enabled = false;
    }

    private IEnumerator OnDrawCoroutine(float radius)
    {
        int maxAngleDeg = 360;
        float angleStep = maxAngleDeg / _vertexAmount * Mathf.Deg2Rad;

        while (_lineRenderer.enabled)
        {
            for (int i = 0; i < _vertexAmount; i++)
            {
                float angle = i * angleStep;
                Vector2 currentPos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

                _lineRenderer.SetPosition(i, new Vector2(currentPos.x + transform.position.x, currentPos.y + transform.position.y));
            }

            yield return null;
        }
    }
}
