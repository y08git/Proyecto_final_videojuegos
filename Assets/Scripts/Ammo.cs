using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject impacto;

    public GameObject spawner_impacto;

    private bool pego = false;

    [SerializeField]
    private float velocidad = 2f;

    [SerializeField]
    private float duracion = 3f;

    private Vector3 fc;

    public void SetSeconds(float seconds){
        this.duracion = seconds;
    }

    public void SetVelocidad(float velocidad){
        this.velocidad = velocidad;
    }

    // Update is called once per frame
    void Start(){
        fc = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().GetFacing();
        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSeconds()
    {
        float elapsedTime = 0;
        while (elapsedTime < duracion && !pego){
            transform.Translate(fc * Time.deltaTime * velocidad, Space.World);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(!pego){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(!pego){
            pego = true;
            var _impacto = spawner_impacto.GetComponent<Spawner>().spawn(impacto, impacto.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spawner"))
            return;
        if (!pego){
            pego = true;
            spawner_impacto.GetComponent<Spawner>().spawn(impacto, impacto.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
