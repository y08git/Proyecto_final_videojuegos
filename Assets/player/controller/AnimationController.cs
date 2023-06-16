using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody _rb;
    private KeyCode up;
    private KeyCode down;
    private KeyCode left;
    private KeyCode right;
    private bool inAir;
    // Start is called before the first frame update
    void Start()
    {
        Movement temp = GetComponent<Movement>();
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        up = temp.up;
        down = temp.down;
        left = temp.left;
        right = temp.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null && _rb != null)
        {
            if ( (Mathf.Abs(_rb.velocity.y) < 0.1f && (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))) && !GetComponent<Movement>().stoppedMove())
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }

    }
}
