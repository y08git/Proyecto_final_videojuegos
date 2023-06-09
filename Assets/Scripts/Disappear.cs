using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disappear());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
