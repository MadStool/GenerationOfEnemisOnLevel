using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = _direction * _speed;
    }

    public void Setup(Vector3 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }
}
