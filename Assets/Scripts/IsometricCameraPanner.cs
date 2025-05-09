using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IsometricCameraPanner : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private Parameters _parameters;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private float _minScroll;
    private float _maxScroll;
    private float _scrollDistance;

    private void Awake()
    {
        _minScroll = _parameters.MinScrollDistance;
        _maxScroll = _parameters.MaxScrollDistance;
        _offset = transform.position - _target.position;
    }

    void Update()
    {
        _camera.fieldOfView -= RecheckScroll( Input.GetAxis("Mouse ScrollWheel"));
    }
    
    private float RecheckScroll(float scroll)
    {
        if (scroll == 0) return 0;
        _scrollDistance = _camera.fieldOfView -= scroll;
        if ((_scrollDistance < _maxScroll) && (_scrollDistance > _minScroll)) return scroll;
        return 0;
    }

    private void LateUpdate()
    {
        Vector3 _targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, smoothTime);
    }



}