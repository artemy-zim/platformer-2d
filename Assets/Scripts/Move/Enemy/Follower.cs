using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private TargetSpotter _spotter;
    [SerializeField] private TargetMover _targetMover;
    [SerializeField] private Transform _player;
    [SerializeField] private Patroller _patroller;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if(_spotter.IsSpotted)
        {
            _targetMover.MoveTowards(_player.position);
            _patroller.enabled = false;
        }
    }
}
