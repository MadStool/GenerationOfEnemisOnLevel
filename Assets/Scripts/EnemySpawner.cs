using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _enemySpeed = 3f;

    private Coroutine _spawningCoroutine;
    private bool _isSpawning;

    public void StartSpawning()
    {
        if (_isSpawning || ValidateSpawnSettings() == false)
            return;

        _isSpawning = true;
        _spawningCoroutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_isSpawning == false) 
            return;

        _isSpawning = false;

        if (_spawningCoroutine != null)
        {
            StopCoroutine(_spawningCoroutine);
            _spawningCoroutine = null;
        }
    }

    private bool ValidateSpawnSettings()
    {
        if (_enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned!", this);
            return false;
        }

        if (_spawnPoints == null || _spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!", this);
            return false;
        }

        return true;
    }

    private void Start() => StartSpawning();
    private void OnDestroy() => StopSpawning();

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (_isSpawning)
        {
            yield return wait;
            SpawnEnemyAtRandomPoint();
        }
    }

    private void SpawnEnemyAtRandomPoint()
    {
        SpawnPoint randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        SpawnEnemy(randomPoint);
    }

    private void SpawnEnemy(SpawnPoint spawnPoint)
    {
        Enemy enemy = Instantiate(
            _enemyPrefab,
            spawnPoint.transform.position,
            Quaternion.identity
        );

        enemy.Initialize(spawnPoint.transform.forward, _enemySpeed);
    }
}