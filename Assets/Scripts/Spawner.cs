using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawn(GameObject toSpawn, Quaternion vector_rotation){
        return Instantiate(toSpawn,transform.position,vector_rotation);
    }
}
