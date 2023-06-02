using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impacto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string tipoImpacto;

    [SerializeField]
    float duracion;

    void Start(){
        StartCoroutine(DestroyImpacto());
    }
    void OnCollisionEnter(Collision collision){
        var _layerMask = collision.gameObject.layer;
        if(LayerMask.NameToLayer(tipoImpacto) == _layerMask){
            collision.gameObject.GetComponent<Health>().takeDamage(1);
        }
    }

    void OnTriggerEnter(Collider collision){
        var _layerMask = collision.gameObject.layer;
        if(LayerMask.NameToLayer(tipoImpacto) == _layerMask){
            collision.gameObject.GetComponent<Health>().takeDamage(1);
        }
    }

    public IEnumerator DestroyImpacto(){
        float elapsedTime = 0;
        while (elapsedTime < duracion){
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }

}
