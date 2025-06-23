using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawningCoroutine;
    private bool _isSpawning;

    public void StartSpawning()
    {
        if (_isSpawning || _spawnPoints == null || _spawnPoints.Length == 0)
        {
            Debug.LogError(_isSpawning ? "Already spawning!" : "No spawn points!", this);
            return;
        }

        _isSpawning = true;
        _spawningCoroutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_isSpawning == false)
            return;

        _isSpawning = false;

        if (_spawningCoroutine != null)
            StopCoroutine(_spawningCoroutine);
    }

    private void Start()
    {
        StartSpawning();
    }

    private void OnDestroy()
    {
        StopSpawning();
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (_isSpawning)
        {
            yield return wait;
            _spawnPoints[Random.Range(0, _spawnPoints.Length)].SpawnEnemy();
        }
    }
}