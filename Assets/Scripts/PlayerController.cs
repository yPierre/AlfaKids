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
    public int count = 0;
    //private Vector3 moveDirection;


    void Start(){
        
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.PlayOneShot(audioCLipArray[28], 0.7f); //Apresentacao
        StartCoroutine(playSoundWithDelay(audioCLipArray[28], 0));
        //StartCoroutine(ExampleCoroutine());
        //audioSource.PlayOneShot(audioCLipArray[29], 0.7f); //Orientacao
        StartCoroutine(playSoundWithDelay(audioCLipArray[29], 4));
        //audioSource.PlayDelayed(2f);
        //audioSource.PlayOneShot(audioCLipArray[23], 0.7f); //Primeira Letra, B
        StartCoroutine(playSoundWithDelay(audioCLipArray[33], 15));


    }

    IEnumerator playSoundWithDelay(AudioClip clip, float delay){
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update(){
        Move();
        //audioSource.PlayOneShot(audioCLipArray[28], 0.7f); //Apresentacao
        //audioSource.PlayOneShot(audioCLipArray[29], 0.7f); //Orientacao
        //audioSource.PlayOneShot(audioCLipArray[23], 0.7f); //Primeira Letra, B
    }

    void Move(){

        Vector3 moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.UpArrow)){
                if(Input.GetKey(KeyCode.LeftShift)){
                    moveDirection = Vector3.forward * speed * 1.8f;
                    anim.SetInteger("transition", 2);
                }
                else{
                    moveDirection = Vector3.forward * speed;
                    anim.SetInteger("transition", 1);
                }
            }
            else{
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
            if(other.gameObject.tag.Contains("X"))
                audioSource.PlayOneShot(audioCLipArray[21], 0.7f);
            if(other.gameObject.tag.Contains("Z"))
                audioSource.PlayOneShot(audioCLipArray[22], 0.7f);
            //Destroy(other.gameObject);
        }
        /*
        if(other.gameObject.tag == "World"){
            Destroy(other.gameObject);
        }
        */
        //if(other.FindGameObjectsWithTag("Letter").Length == 0){

        //}
        if(other.gameObject.tag.Contains("Letter") || other.gameObject.tag.Contains("Fruit")){
            if(other.gameObject.tag == "LetterB" && count == 0){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[26], 5));
                count++;
            }
            else if(other.gameObject.tag == "FruitPumpkim" && count == 1){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[34], 5));
                count++;
            }
            else if(other.gameObject.tag == "LetterC" && count == 2){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[23], 5));
                count++;
            }
            else if(other.gameObject.tag == "FruitBanana" && count == 3){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[36], 5));
                count++;
            }
            else if(other.gameObject.tag == "LetterM" && count == 4){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[27], 5));
                count++;
            }
            else if(other.gameObject.tag == "FruitCarrot" && count == 5){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[37], 5));
                count++;
            }
            else if(other.gameObject.tag == "LetterS" && count == 6){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[25], 5));
                count++;
            }
            else if(other.gameObject.tag == "FruitApple" && count == 7){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[35], 5));
                count++;
            }
            else if(other.gameObject.tag == "LetterK" && count == 8){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[24], 5));
                count++;
            }
            else if(other.gameObject.tag == "FruitCandy" && count == 9){
                Destroy(other.gameObject);
                StartCoroutine(playSoundWithDelay(audioCLipArray[32], 1));
                StartCoroutine(playSoundWithDelay(audioCLipArray[30], 5));
                count++;
            }
            else{
                StartCoroutine(playSoundWithDelay(audioCLipArray[31], 1));
            }
        }
        
    }

    

}
