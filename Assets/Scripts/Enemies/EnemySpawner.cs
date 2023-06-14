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

    private List<MeeleEnemy> instances;

    private int dead_instances;

    void Start(){
        dead_instances = 0;
        instances = new List<MeeleEnemy>();
        _dangerZone = dangerZone.GetComponent<DangerZone>();
        _meele_enemy = meele_enemy.GetComponent<MeeleEnemy>();
    }

    void Update(){
        if(_dangerZone.getTarjetOnRange() & !spawning){
            _meele_enemy._objetivo = _dangerZone.getTarjet().transform;
            StartCoroutine(SpawnEnemy());
        }
        if(spawned)
            GetComponent<MeshRenderer>().enabled = false;
            spawned = false;
        CheckDeads();
    }

    private void CheckDeads(){
        var removal = new List<int>();
        for (int i = 0; i < instances.Count; i++)
        {
            if(instances[i].isDead()){
                dead_instances += 1;
                removal.Add(i);
            }
        }
        foreach (int index in removal)
        {
            instances.RemoveAt(index);
        }
    }

    public int GetDeads(){
        return dead_instances;
    }

    public int GetnEnemies(){
        return n_enemies;
    }

    IEnumerator SpawnEnemy(){
        spawning = true;
        for(int i=0; i<n_enemies;i++){
            GameObject instance = Instantiate(meele_enemy,transform.position,meele_enemy.transform.rotation);
            instances.Add(instance.GetComponent<MeeleEnemy>());
            yield return new WaitForSeconds(rate_spawn);
        }
        spawned = true;
    }
}
