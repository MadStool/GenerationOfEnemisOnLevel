using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    public void Initialize(Vector3 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _direction * _speed;
    }

    public void SetDirection(Vector3 newDirection) => _direction = newDirection.normalized;
    public void SetSpeed(float newSpeed) => _speed = newSpeed;
}