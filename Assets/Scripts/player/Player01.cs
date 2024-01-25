using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01 : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    [SerializeField]
    private Rigidbody2D charBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded;
    private string GROUND_TAG = "Ground"; // tag

    private void Awake(){
        charBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        charBody.AddForce(new Vector2(2, 2));
    }//Awake

    // Start is called before the first frame update
    void Start()
    {
        
    }//Start

    // Update is called once per frame
    void Update()
    {
        playerMovementKeyboard();
        AnimatePlayer();
    }//Update

    private void FixedUpdate(){
        playerJump();
    }// FixedUpdate

    void playerMovementKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        //Debug.Log("Movement value :"+ movementX); // testing
        
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }// playerMovementKeyboard

    void AnimatePlayer(){
        if (movementX > 0){    // move right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;   // flip character to right
        }else if(movementX < 0){    // move left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;    // flip character to left
        }else{  // stop moving
            anim.SetBool(WALK_ANIMATION, false);
        }
    }// AnimatePlayer

    void playerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            Debug.Log("Key pressed : Jump");

            if(charBody != null){
                isGrounded = false;
                charBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }else{
                Debug.Log("Rigidbody2D not found");
            }
        }
    }//playerJump

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG)){    // check if the player has landed on ground
            isGrounded = true;
            //Debug.Log("Landed on ground");    // testing
        }
    }// OnCollisionEnter2D

}// class Player01