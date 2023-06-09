using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;

    private float f_health;

    private float maxValHealthBar;
    private float minValHealthBar;

    public bool died = false;

    Transform _tr; 

    void Start(){
        f_health = (float) this.health;
        _tr = GameObject.Find("Canvas/HealthBar").transform;
        maxValHealthBar = _tr.position.x;
        minValHealthBar = maxValHealthBar - 230;
    }

    void Update(){
        if(f_health <= 0){
            died = true; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void takeDamage(int damage){
        f_health -= damage;
        _tr.position = new Vector3(minValHealthBar + (((maxValHealthBar - minValHealthBar) / health) * f_health), _tr.position.y, _tr.position.z);
    }

    public float getHealth(){
        return this.f_health;
    }

    public void takeDamageOverTime(int damage){
        f_health -= damage*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "trampa")
        {
            takeDamage(3);
        }
    }
}
