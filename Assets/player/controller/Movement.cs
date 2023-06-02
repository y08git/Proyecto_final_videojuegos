using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 facing;
    private bool enteredIf;
    private float currentSpeed;
    private Weapon1[] weapons;
    Rigidbody _rb;
    Transform _tr;
    RectTransform _trCanvas;
    bool canJump;
    public float airPenalty;
    public float movementSpeed;
    public float jumpHeight;
    public float maxSpeed;  
    public LayerMask layermask;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shootJump;
    public int airMunition;
    public float airRechargeTime;
    private int currentAirMunition;
    private bool recharging;
    private float maxValHealthBar;
    private float minValHealthBar;
    public TMP_Text tmp;
    Weapon wp;
    void Start()
    {
        canJump = true;
        _rb = GetComponent<Rigidbody>(); 
        _tr = GetComponent<Transform>(); 
        facing = new Vector3(1,0,0);
        weapons = new Weapon1[3];
        weapons[0] = new Pistol(10.0f, 1.0f, 1.0f, 45.0f);
        currentAirMunition = airMunition;
        recharging = false;
        wp = this.gameObject.GetComponent<Player>().GetWeapon();
        _trCanvas = GameObject.Find("Canvas/Recharge").GetComponent<RectTransform>();
        maxValHealthBar = _trCanvas.position.x;
        minValHealthBar -= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(!recharging && (currentAirMunition < airMunition))
        {
            recharging = true;
            StartCoroutine(RechargeAirMunition());
        }
        if (Input.GetKeyDown(jump) && canJump)
        {
            canJump = false;
            _rb.AddForce(jumpHeight * Vector3.up, ForceMode.VelocityChange);
        }
        enteredIf = false;
        if (Input.GetKey(up))
        {
            //_rb.AddForce(Vector3.forward * movementSpeed, ForceMode.VelocityChange);
            //_tr.LookAt(_tr.position + Vector3.forward;
            facing = Vector3.forward;
            enteredIf = true;
        } 
        else if (Input.GetKey(down))
        {   
            //_rb.AddForce(Vector3.back * movementSpeed, ForceMode.VelocityChange);
            //_tr.LookAt(_tr.position + Vector3.back);
            facing = Vector3.back;
            enteredIf = true;
        }
        if (Input.GetKey(left))
        {
            //_rb.AddForce(Vector3.left * movementSpeed, ForceMode.VelocityChange);
            //_tr.LookAt(_tr.position + Vector3.left);
            facing =(enteredIf)? facing + Vector3.left :Vector3.left;
            enteredIf = true;
        }
        else if (Input.GetKey(right))
        {
            //_rb.AddForce(Vector3.right * movementSpeed, ForceMode.VelocityChange);
            //_tr.LookAt(_tr.position + Vector3.right);
            facing = (enteredIf) ? facing + Vector3.right : Vector3.right;
            enteredIf = true;
        }
        _tr.LookAt(_tr.position + facing);
        currentSpeed += (currentSpeed < maxSpeed) ? Time.fixedDeltaTime * movementSpeed : 0 ; //no utilizamos addforce por que salen cosas raras
        if (enteredIf)
        {
            facing.Normalize();
            if (canJump)
            {
                _rb.velocity = facing * currentSpeed + Vector3.up * _rb.velocity.y;
            }else
            {
                if (_rb.velocity.magnitude < maxSpeed)
                {
                    _rb.velocity += facing * movementSpeed * airPenalty * Time.deltaTime;
                }
            }
        }
        if(Input.GetKeyDown(shootJump) && (currentAirMunition > 0) && wp.ready_fire)
        {
            wp.Disparo();
            currentAirMunition--;
            tmp.text = "" + currentAirMunition;
            canJump = false;
            _rb.velocity = weapons[0].getFlyingDirection(facing);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }
    IEnumerator RechargeAirMunition()
    {
        float tempCount = 0f;
        while (airMunition > currentAirMunition)
        {
            if (canJump)
            {
                if (tempCount >= airRechargeTime)
                {
                    currentAirMunition++;
                    tmp.text = "" + currentAirMunition;
                    tempCount = 0f;
                }
                else
                {
                    tempCount += Time.deltaTime;
                }
            }
            _trCanvas.position = new Vector3(minValHealthBar + (((maxValHealthBar - minValHealthBar) / airRechargeTime) * tempCount), _trCanvas.position.y, _trCanvas.position.z);
            yield return new WaitForEndOfFrame();
        }
        _trCanvas.position = new Vector3(maxValHealthBar, _trCanvas.position.y, _trCanvas.position.z);
        recharging = false;
    }
    public Vector3 GetFacing()
    {
        return facing;
    }

}
