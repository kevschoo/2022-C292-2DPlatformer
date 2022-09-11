using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] float _enemySpawnCooldown = 2f;
    //[SerializeField] GameObject _en1, _en2, _en3, _en4, _en5, _en6;
    [SerializeField] float _xMin = 0;
    [SerializeField] float _xMax = 0;
    [SerializeField] float _YSpawn = 0;
    [SerializeField] List<GameObject> Enemies = new List<GameObject> {};
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _YSpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
        if(Enemies.Count != 0)
        {
        InvokeRepeating("SpawnEnemy", 0, _enemySpawnCooldown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCooldown();
    }

    void SpawnEnemy()
    {
        rand = Random.Range(0, Enemies.Count);
        float randX = Random.Range(_xMin,_xMax);
        Instantiate(Enemies[rand], new Vector3(randX, _YSpawn, 0), Quaternion.identity);
    }

    void SpawnCooldown()
    {
        int curScore = GameController.Instance.getScore();
        _enemySpawnCooldown = 500/(curScore+750);
    }
}
