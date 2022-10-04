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
    public AudioSource audioSource;
    public AudioClip [] audioCLipArray;
    //private Vector3 moveDirection;


    void Start(){
        
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();


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
        if(other.gameObject.tag.Contains("Letter")){
            if(other.gameObject.tag.Contains("A"))
                audioSource.PlayOneShot(audioCLipArray[0], 0.7f);
            if(other.gameObject.tag.Contains("B"))
                audioSource.PlayOneShot(audioCLipArray[1], 0.7f);
            if(other.gameObject.tag.Contains("C"))
                audioSource.PlayOneShot(audioCLipArray[2], 0.7f);
            if(other.gameObject.tag.Contains("D"))
                audioSource.PlayOneShot(audioCLipArray[3], 0.7f);
            if(other.gameObject.tag.Contains("E"))
                audioSource.PlayOneShot(audioCLipArray[4], 0.7f);
            if(other.gameObject.tag.Contains("F"))
                audioSource.PlayOneShot(audioCLipArray[5], 0.7f);
            if(other.gameObject.tag.Contains("G"))
                audioSource.PlayOneShot(audioCLipArray[6], 0.7f);
            if(other.gameObject.tag.Contains("H"))
                audioSource.PlayOneShot(audioCLipArray[7], 0.7f);
            if(other.gameObject.tag.Contains("I"))
                audioSource.PlayOneShot(audioCLipArray[8], 0.7f);
            if(other.gameObject.tag.Contains("J"))
                audioSource.PlayOneShot(audioCLipArray[9], 0.7f);
            //if(other.gameObject.tag.Contains("K"))
            //    audioSource.PlayOneShot(audioCLipArray[10], 0.7f);
            if(other.gameObject.tag.Contains("rL"))
                audioSource.PlayOneShot(audioCLipArray[10], 0.7f);
            if(other.gameObject.tag.Contains("M"))
                audioSource.PlayOneShot(audioCLipArray[11], 0.7f);
            if(other.gameObject.tag.Contains("N"))
                audioSource.PlayOneShot(audioCLipArray[12], 0.7f);
            if(other.gameObject.tag.Contains("O"))
                audioSource.PlayOneShot(audioCLipArray[13], 0.7f);
            if(other.gameObject.tag.Contains("P"))
                audioSource.PlayOneShot(audioCLipArray[14], 0.7f);
            if(other.gameObject.tag.Contains("Q"))
                audioSource.PlayOneShot(audioCLipArray[15], 0.7f);
            if(other.gameObject.tag.Contains("R"))
                audioSource.PlayOneShot(audioCLipArray[16], 0.7f);
            if(other.gameObject.tag.Contains("S"))
                audioSource.PlayOneShot(audioCLipArray[17], 0.7f);
            if(other.gameObject.tag.Contains("T"))
                audioSource.PlayOneShot(audioCLipArray[18], 0.7f);
            if(other.gameObject.tag.Contains("U"))
                audioSource.PlayOneShot(audioCLipArray[19], 0.7f);
            if(other.gameObject.tag.Contains("V"))
                audioSource.PlayOneShot(audioCLipArray[20], 0.7f);
            //if(other.gameObject.tag.Contains("W"))
            //    audioSource.PlayOneShot(audioCLipArray[22], 0.7f);
            if(other.gameObject.tag.Contains("X"))
                audioSource.PlayOneShot(audioCLipArray[21], 0.7f);
            //if(other.gameObject.tag.Contains("Y"))
            //    audioSource.PlayOneShot(audioCLipArray[24], 0.7f);
            if(other.gameObject.tag.Contains("Z"))
                audioSource.PlayOneShot(audioCLipArray[22], 0.7f);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "World"){
            Destroy(other.gameObject);
        }
    }

    

}
