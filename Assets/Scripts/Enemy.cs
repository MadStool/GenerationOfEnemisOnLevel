using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    public void Setup(Vector3 direction, float speed)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _direction = direction.normalized;
        _speed = speed;
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null)
            _rigidbody.linearVelocity = _direction * _speed;
    }
}