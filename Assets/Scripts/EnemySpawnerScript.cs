using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] float _enemySpawnCooldown = 2f;
    [SerializeField] GameObject _enemyPreFab;
    [SerializeField] float _xMin = 0;
    [SerializeField] float _xMax = 0;
    [SerializeField] float _YSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _YSpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
        InvokeRepeating("SpawnEnemy", 0, _enemySpawnCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randX = Random.Range(_xMin,_xMax);
        Instantiate(_enemyPreFab, new Vector3(randX, _YSpawn, 0), Quaternion.identity);
    }
}
