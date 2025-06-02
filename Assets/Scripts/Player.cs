using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Parameters _parameters;
    private Vector3 _input;
    private bool _onStop=false;
    private float _actualSpeed;
    private Enemy _enemy;
    private void Update()
    {
        if (_onStop) return;
        GatherInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _actualSpeed = _parameters.PlayerRunSpeed;
        }
        else _actualSpeed = _parameters.PlayerSpeed;
    }

    public void HitEnemy()
    {
        if (_enemy == null) return;
        _enemy.GetHit();
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void DeleteEnemy()
    {
        _enemy = null;
    }

    public void StopPlayer()
    {
        _onStop=true;
    }

    public void RunPlayer()
    {
        _onStop = false;
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }
    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (_input == Vector3.zero) _rb.linearVelocity = Vector3.zero;
    }
    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            _rb.rotation = rot;

        }

    }
    private void Move()
    {
        _rb.linearVelocity=(transform.forward * _input.magnitude * _actualSpeed);
    }

}
