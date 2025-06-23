using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _enemySpeed = 3f;

    public Enemy SpawnEnemy()
    {
        if (_enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned!", this);
            return null;
        }

        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.Initialize(transform.forward, _enemySpeed);
        return enemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.25f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}