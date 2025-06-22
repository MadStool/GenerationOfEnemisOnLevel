using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _enemySpeed = 3f;

    private Coroutine _spawningCoroutine;
    private bool _isSpawning;

    private void Start()
    {
        if (_spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        StartSpawning();
    }

    private void OnDestroy()
    {
        StopSpawning();
    }

    public void StartSpawning()
    {
        if (_isSpawning)
            return;

        _isSpawning = true;
        _spawningCoroutine = StartCoroutine(SpawnEnemiesRoutine());
    }

    public void StopSpawning()
    {
        if (_isSpawning == false)
            return;

        _isSpawning = false;

        if (_spawningCoroutine != null)
            StopCoroutine(_spawningCoroutine);
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(_spawnInterval);
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        IMovableEnemy enemy = _spawnPoints[randomIndex].SpawnEnemy();

        if (enemy != null)
        {
            enemy.Speed = _enemySpeed;
        }
    }
}