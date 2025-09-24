using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D myCharacterController;
    public AudioSource footSteps;
    private bool isMoving = false;
    //public Animator myAnimator;

    public float speed = 30f;

    float horizontalMove = 0f;
    bool jumping = false;


    void Start()
    {
        myCharacterController = GetComponent<CharacterController2D>();
        //myAnimator = GetComponent<Animator>();

        footSteps = GetComponent<AudioSource>();
        //footSteps.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }

        //if moving play the footSteps

        if (horizontalMove == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        //Debug.Log(horizontalMove);


        //Debug.Log(jumping);
    }

    private void FixedUpdate()
    {
        myCharacterController.Move(horizontalMove * Time.fixedDeltaTime, false, jumping, isMoving);
        jumping = false;
    }

}  