using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private int n_enemies;

    [SerializeField]
    private GameObject meele_enemy;

    private MeeleEnemy _meele_enemy;

    [SerializeField]
    private float rate_spawn;

    private bool spawning=false;

    private bool spawned=false;

    public GameObject dangerZone;
    private DangerZone _dangerZone;

    void Start(){
        _dangerZone = dangerZone.GetComponent<DangerZone>();
        _meele_enemy = meele_enemy.GetComponent<MeeleEnemy>();
    }

    void Update(){
        if(_dangerZone.getTarjetOnRange() & !spawning){
            _meele_enemy._objetivo = _dangerZone.getTarjet().transform;
            Spawn();
        }
        if(spawned)
            Destroy(gameObject);
    }

    public void Spawn(){
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        spawning = true;
        for(int i=0; i<n_enemies;i++){
            Instantiate(meele_enemy,transform.position,meele_enemy.transform.rotation);
            yield return new WaitForSeconds(rate_spawn);
        }
        spawned = true;
    }
}
