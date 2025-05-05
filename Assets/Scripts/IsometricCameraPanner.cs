using UnityEngine;

public class IsometricCameraPanner : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 _targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, smoothTime);
    }



}