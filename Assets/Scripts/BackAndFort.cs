using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndFort : MonoBehaviour
{

    public float x;
    bool d1;
    private float posfin;
    // Start is called before the first frame update
    void Start()
    {
        d1 = true; 
        posfin = x + transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (d1)
        {
            transform.Translate(Vector3.forward * x * Time.deltaTime);
            if(transform.position.z >= posfin)
            {
                d1 = false;
            }

        }
        else
        {
            transform.Translate(Vector3.back * x * Time.deltaTime);
            if (transform.position.z < posfin - x)
            {
                d1 = true;
            }
        }
    }
}
