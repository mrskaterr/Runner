using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] float Speed;
    // [SerializeField] float JumpPower;
    // bool isGounded;
    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    //     if(Speed>0)
    //     {
    //         gameObject.transform.position+=new Vector3(Speed,0,0);
    //     }
        
    //     if(Input.GetKey(KeyCode.Space) && isGounded)
    //     {
    //         gameObject.GetComponent<Rigidbody>().velocity+=new Vector3(0,JumpPower,0);
    //     }
    // }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("Collision");
    //     if(collision.gameObject.GetComponent<Cube>())
    //     {
    //         Debug.Log("Cube");
    //         Speed=0;
    //     }
    //     else if(collision.gameObject.GetComponent<Ground>())
    //     {
    //         isGounded=true;
    //     }

    // }
    // void OnCollisionExit(Collision collision)
    // {
    //     if(collision.gameObject.GetComponent<Ground>())
    //     {
    //         isGounded=false;
    //     }
    // }
    
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.GetComponent<Cube>())
        {
            Debug.Log("Cubehit");
            speed=0;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.GetComponent<Cube>())
        {
            Debug.Log("Cube");
            speed=0;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Slowling>())
        {
            speed/=2;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.GetComponent<Slowling>())
        {
            speed*=2;
        }
    }

}
