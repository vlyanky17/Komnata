using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Parameters _parameters;
    private Vector3 _input;
    private bool _onStop=false;
    private float _actualSpeed;
    private void Update()
    {
        if (_onStop) return;
        GatherInput();
        Look();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _actualSpeed = _parameters.PlayerRunSpeed;
        }
        else _actualSpeed = _parameters.PlayerSpeed;
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
    }
    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = rot;

        }

    }
    private void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _actualSpeed * Time.deltaTime);

    }

}
