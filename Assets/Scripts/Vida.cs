using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int health;

    private float f_health;

    private float maxValHealthBar;
    private float minValHealthBar;

    public bool died = false;

    private Animator _animator;

    Transform _tr; 

    void Start(){
        f_health = (float) this.health;
    }

    void Update(){
        if(f_health <= 0){
            died = true;
        }
    }

    public void takeDamage(int damage){
        f_health -= damage;
        StartCoroutine(DisplayAnimation());
    }

    private IEnumerator DisplayAnimation(){
        _animator.SetBool("Damage",true);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Damage",false);
    }

    public float getHealth(){
        return this.f_health;
    }

    public void takeDamageOverTime(int damage){
        f_health -= damage*Time.deltaTime;
    }

    public void setAnimator(Animator animator){
        this._animator = animator;
    }
}
