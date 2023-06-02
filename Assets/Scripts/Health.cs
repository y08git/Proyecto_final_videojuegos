using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    private float f_health;

    private float maxHealth;
    private float minHealth;

    void Start(){
        f_health = (float) this.health;
    }

    void Update(){
        if(f_health <= 0){
            this.gameObject.GetComponent<Death>().Die();
        }
    }

    public void takeDamage(int damage){
        f_health -= damage;
        Debug.Log(f_health);
    }

    public float getHealth(){
        return this.f_health;
    }

    public void takeDamageOverTime(int damage){
        f_health -= damage*Time.deltaTime;
    }
}
