using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField, Range(0, float.MaxValue)] private float _colorCooldown;

    private Color _defaultColor; 
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _defaultColor = _renderer.color;
    }

    public void Change()
    {
        _renderer.color = color;
        Invoke(nameof(Reset), _colorCooldown);
    }

    private void Reset()
    {
        _renderer.color = _defaultColor;
    }
}
