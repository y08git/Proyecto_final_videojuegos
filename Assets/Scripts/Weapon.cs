using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public GameObject spawner_municion;
    public GameObject municion;

    int cargador;

    public float poder_disparo;

    int daño;

    [SerializeField]
    float cadencia = 1;

    [SerializeField]
    AudioSource _audioSource_shoot;
    
    float duracion_recarga;

    public float magnitud_fuerza_empuje;

    public bool ready_fire = true;

    public IEnumerator Disparo(){
        ready_fire = false;
        _audioSource_shoot.Play();
        float elapsedTime = 0;
        while (elapsedTime < cadencia){
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        ready_fire = true;
    }

    public void dispara_projectil(){
        var proyectil = spawner_municion.GetComponent<Spawner>().spawn(municion, municion.transform.rotation);
        StartCoroutine(Disparo());
    }
}
