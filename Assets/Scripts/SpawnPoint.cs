using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _enemyPrefab;

    public IMovableEnemy SpawnEnemy()
    {
        MonoBehaviour enemyInstance = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemyInstance.TryGetComponent(out IMovableEnemy movableEnemy))
        {
            movableEnemy.SetDirection(transform.forward);
            return movableEnemy;
        }
        else
        {
            Debug.LogWarning("Enemy prefab doesn't have IMovableEnemy component!");
            return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}