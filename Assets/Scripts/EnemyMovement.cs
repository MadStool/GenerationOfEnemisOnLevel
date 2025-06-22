using UnityEngine;

public interface IMovableEnemy
{
    void SetDirection(Vector3 direction);
    float Speed { get; set; }
}

public class EnemyMovement : MonoBehaviour, IMovableEnemy
{
    [SerializeField] private float _speed = 3f;
    private Vector3 _direction;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection.normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}