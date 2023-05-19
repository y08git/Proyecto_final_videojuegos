using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Transform target;
    Transform cam;
    public float limitUpperY;
    public float limitLowerY;
    public Vector3 positionRelativeToTarget;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam = this.transform;
        cam.position = target.position + positionRelativeToTarget;
        cam.LookAt(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > limitLowerY && target.position.y < limitUpperY) //revisa que la cámara este en rango de y, para que no se vaya muy arriba ni muy abajo
        {
            cam.position = target.position + positionRelativeToTarget;
        }
    }
}
