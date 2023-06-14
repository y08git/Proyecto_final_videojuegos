using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrier : MonoBehaviour
{
    public GameObject _spawner;

    private EnemySpawner _enemySpawner;
    void Start()
    {
        _enemySpawner = _spawner.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemySpawner.GetnEnemies() == _enemySpawner.GetDeads())
            Destroy(gameObject);
    }
}
