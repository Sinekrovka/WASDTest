using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<Enemy> _enemiesExample;
    [SerializeField] private List<Transform> spawnPoints;
    
    public static EnemiesController Instance;

    private List<Enemy> _pool;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        GameObject enemies = new GameObject("Enemies");
        _pool = new List<Enemy>();
        for (int i = 0; i < _poolSize; ++i)
        {
            var newEnemy =
                Instantiate(_enemiesExample[Random.Range(0, _enemiesExample.Count)], 
                    spawnPoints[Random.Range(0, spawnPoints.Count)].position,
                    Quaternion.identity, enemies.transform);
            newEnemy.SetPlayer(_player);
            newEnemy.gameObject.SetActive(false);
            _pool.Add(newEnemy);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        _pool[0].transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        _pool[0].gameObject.SetActive(true);
        _pool.RemoveAt(0);
        StartCoroutine(SpawnEnemies());
    }

    public void KillEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _pool.Add(enemy);
    }
}
