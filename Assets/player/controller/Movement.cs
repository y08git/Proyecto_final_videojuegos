using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 facing;
    private bool enteredIf;
    Rigidbody _rb;
    Transform _tr;
    bool canJump;
    public float movementSpeed;
    public float jumpHeight;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    void Start()
    {
        canJump = true;
        _rb = GetComponent<Rigidbody>(); 
        _tr = GetComponent<Transform>(); 
        facing = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump) && canJump)
        {
            canJump = false;
            Debug.Log("Jumped?");
            _rb.AddForce(jumpHeight * Vector3.up, ForceMode.VelocityChange);
        }
        /*
        if (Input.GetKeyDown(up))
        {
            _tr.LookAt(_tr.position + Vector3.forward);
        }
        if (Input.GetKeyDown(down))
        {
            _tr.LookAt(_tr.position + Vector3.back);
        }
        if (Input.GetKeyDown(left))
        {
            _tr.LookAt(_tr.position + Vector3.left);
        }
        if (Input.GetKeyDown(right))
        {
            _tr.LookAt(_tr.position + Vector3.right);
        }*/


    }
    private void FixedUpdate()
    {
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
        if (enteredIf)
        {
            facing.Normalize();
            _rb.AddForce(facing * movementSpeed, ForceMode.VelocityChange);
        }
        _tr.LookAt(_tr.position + facing);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }

    /**
     * 
     */
    Vector3 GetFacing()
    {
        return facing;
    }
    void pistolMovement()
    {
        
    }
}
