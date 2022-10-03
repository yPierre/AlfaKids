using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    // Start is called before the first frame update

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float jumpHeight = 1.0f;
    private Animator anim;
    public float speed;
    public float gravity;
    public float rotSpeed;
    private float rot;
    //private Vector3 moveDirection;


    void Start(){
        
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){

        Vector3 moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.W)){
                if(Input.GetKey(KeyCode.LeftShift)){
                    moveDirection = Vector3.forward * speed * 1.5f;
                    anim.SetInteger("transition", 2);
                }
                else{
                    moveDirection = Vector3.forward * speed;
                    anim.SetInteger("transition", 1);
                }
            }
            if(Input.GetKeyUp(KeyCode.W)){
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded){
            moveDirection.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Fruit"){
            Destroy(other.gameObject);
        }
    }

}
