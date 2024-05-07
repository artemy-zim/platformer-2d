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

    public void ChangeColor()
    {
        _renderer.color = color;
        Invoke(nameof(ResetColor), _colorCooldown);
    }

    private void ResetColor()
    {
        _renderer.color = _defaultColor;
    }
}
