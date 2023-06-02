using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private string layer_name;

    private bool tarjetOnRange = false;

    private GameObject tarjet;
    // Start is called before the first frame update
    void Start()
    {
        setRadius(this.radius);
    }

    float DistanceFrom(Transform objetive){
        return Mathf.Abs((objetive.position - transform.position).magnitude);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collision){
        if(tarjetOnRange)
            return;
        Debug.Log("Hooola");
        if(collision.gameObject.layer == LayerMask.NameToLayer(layer_name))
            this.tarjetOnRange = true;
            this.tarjet = collision.gameObject;
    }

    public void setTarjetOnRange(bool state){
        this.tarjetOnRange = state;
    }

    public bool getTarjetOnRange(){
        return this.tarjetOnRange;
    }

    public void setRadius(float radius){
        this.radius = radius;
        transform.localScale += new Vector3(1f,0f,1f)*this.radius;
    }

    public float getRadius(){
        return this.radius;
    }

    public GameObject getTarjet(){
        return this.tarjet;
    }

    public void setTarjetNull(){
        this.tarjet = null;
    }
}
