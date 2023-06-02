using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    public GameObject dangerZone;
    private DangerZone _dangerZone;
    private Quaternion direction;

    private Animator _animator;

    // public GameObject objetivo;

    public Transform _objetivo;

    // private Transform _objetivo;

    public float maxSpeed = 5f;
    public float turnSpeed = 0.75f;
    public float duration = 1f;

    public float atack_duration = 3;

    [SerializeField]
    private int damage;

    private bool toco = false;
    private bool moving = false;
    private bool atacking = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = transform.GetChild(1).GetComponent<Animator>();
        _dangerZone = dangerZone.GetComponent<DangerZone>();
    }

    void Update()
    {   
        var distance_from_objetivo = DistanceFrom(_objetivo);
        Debug.Log(distance_from_objetivo);
        var is_onRange = distance_from_objetivo <= _dangerZone.getRadius()*0.8f;
        var not_onRange = distance_from_objetivo > _dangerZone.getRadius()*1.1f;
        if(not_onRange){
            toco = false;
            _dangerZone.setTarjetOnRange(false);
        }
        if(distance_from_objetivo <= _dangerZone.getRadius()*0.5f)
            toco = true;
        if(toco & !atacking)
            StartCoroutine(Atack());
        if(!moving){
            StartCoroutine(MoveForwardTo(_objetivo));
        }
    }

    IEnumerator Atack(){
        atacking = true;
        var _health = _dangerZone.getTarjet().GetComponent<Health>();
        while(toco){
            _animator.SetBool("Hit",true);
            yield return new WaitForSeconds(atack_duration);
            _health.takeDamage(damage);
            yield return 0;
        }
        atacking = false;
        _animator.SetBool("Hit",false);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            toco = true;
    }

    IEnumerator MoveForwardTo(Transform objetivo){
        moving = true;
        while(!toco){
        direction = LookAt(objetivo);
        _rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation,LookAt(objetivo),turnSpeed));
        _rigidbody.MovePosition(transform.position + transform.forward*maxSpeed*Time.deltaTime);
        _animator.SetFloat("Walk",1f);
        yield return 0;
        }
        _rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation,LookAt(objetivo),turnSpeed));
        _animator.SetFloat("Walk",0f);
        moving = false;
    }

    Quaternion LookAt(Transform objetivo){
        var a = transform.rotation.eulerAngles;
        // return Quaternion.Euler(a + new Vector3(0f,Vector3.Angle(objetivo.position - transform.position,transform.forward),0f));
        return Quaternion.LookRotation((objetivo.position - transform.position).normalized);
    }

    float DistanceFrom(Transform objetive){
        return Mathf.Abs((objetive.position - transform.position).magnitude);
    }

    private AnimationClip FindAnimation(string name) 
    {
        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }
}
