using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 100f;

    bool jump  = false;

   // public GameObject GameOver, Restart;

    public Animator animator;

    // [SerializeField] private float speed;
    // private Rigidbody2D body;

    // private void Awake(){
    //     body = GetComponent<Rigidbody2D>();
    // }


    // void Start(){
    //     GameOver.SetActive(false);
    //     Restart.SetActive(false);
    // }

    void Update(){

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if(Input.GetButtonDown("Jump")){
            jump = true;

            animator.SetBool("Isjumping", true);
        }

       
    
        // body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed , body.velocity.y);

        // if(Input.GetKey(KeyCode.Space))
        //     body.velocity = new Vector2(body.velocity.x, speed/2);

    }

    public void OnLanding(){
            animator.SetBool("Isjumping", false);
    }


    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }

    // void OnCollisionEnter2D(Collision2D col){
    //     if(col.gameObject.tag.Equals("Enemy")){
    //         GameOver.SetActive(true);
    //         Restart.SetActive(true);
    //         gameObject.SetActive(false);
    //     }
    // }


}