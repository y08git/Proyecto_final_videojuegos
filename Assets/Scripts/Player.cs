using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject pistola;
    public GameObject lanzallamas;
    public GameObject lanzacohetes;
    private GameObject arma;
    private Movement mv;

    public KeyCode disparo;

    // 0: pistola
    // 1: lanzallamas
    // 2: lanzacohetes
    private int armaIndex;

    private void Awake()
    {
        arma = pistola;
    }
    public float velocidad_movimiento;
    public int direccion;
    Rigidbody _rigidBody;

    [SerializeField]
    AudioSource _maintheme;

    void Start(){
        _maintheme.Play();
        _rigidBody = GetComponent<Rigidbody>();
        mv = GetComponent<Movement>();
        //armaIndex = 0;
    }

    void Update(){
        if(Input.GetKey(disparo)){
            disparar();
        }
    }

    void disparar(){
        if(arma.GetComponent<Weapon>().ready_fire){
            arma.GetComponent<Weapon>().dispara_projectil();
            transform.Translate((mv.GetFacing()) * Time.deltaTime * arma.GetComponent<Weapon>().magnitud_fuerza_empuje);
        }
    }

    public Weapon GetWeapon()
    {
        return arma.GetComponent<Weapon>();
    }
}
