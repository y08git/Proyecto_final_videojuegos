using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public Vector3 newAngle;
    public GameObject cam;
    //private Vector3 tempVect;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //tempVect = cam.GetComponent<cameraMovement>().positionRelativeToTarget;
        cam.GetComponent<cameraMovement>().positionRelativeToTarget = newAngle;
        Destroy(this.gameObject);
        //newAngle = tempVect;
    }

}
