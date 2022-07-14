using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class Himanshu : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;
    private bool isGrounded=true;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION= "Walk";
    private string GROUND_TAG= "Ground";
    private string ENEMY_TAG= "Enemy";

    

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
        myBody= GetComponent<Rigidbody2D>();
        
     
    }

    // Update is called once per frame
    void Update()
    {
       

        PlayerMoveKeyboard();
        AnimatePlayer();
        
    }

    private void FixedUpdate() {
        PlayerJump();
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        
      
    }

    void AnimatePlayer(){
       
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false;
        } else if(movementX < 0){
             anim.SetBool(WALK_ANIMATION,true);
             sr.flipX=true;
        } else{
             anim.SetBool(WALK_ANIMATION,false);
        }
    }
    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded= false;
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(GROUND_TAG)){
            isGrounded= true;
        }
        if(other.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
            
        }

    }

    
}
