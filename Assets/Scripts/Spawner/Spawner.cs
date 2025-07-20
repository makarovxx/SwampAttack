using System;
using Enemy;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Transform _spawnPoint;
    [FormerlySerializedAs("_player")] [SerializeField] private Player.PlayerController playerController;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event Action AllEnemySpawned;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null) return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            SpawnEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0f;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Length > _currentWaveIndex + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private void OnEnemyDying(LiveUnit liveUnit)
    {
        liveUnit.OnDie -= OnEnemyDying;
        if (liveUnit is Enemy.Enemy enemy)
            playerController.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _spawned = 0;
    }

    private void SpawnEnemy()
    {
        Enemy.Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint)
            .GetComponent<Enemy.Enemy>();
        enemy.Init(playerController);
        enemy.OnDie += OnEnemyDying;
    }

    private void SetWave(int waveIndex) => _currentWave = _waves[waveIndex];
}