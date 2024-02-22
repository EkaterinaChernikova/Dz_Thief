using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _rotationSpeed = 240;

    private Animator _animator;
    private float _animationSwitch = 0.0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime);

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            _animationSwitch = 0.05f;
        }
        else
        {
            _animationSwitch = 0.0f;
        }

        _animator.SetFloat(Speed, _animationSwitch);
    }
}