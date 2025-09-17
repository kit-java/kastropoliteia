using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D myCharacterController;
    //public Animator myAnimator;


    public float speed = 30f;

    float horizontalMove = 0f;
    bool jumping = false;


    void Start()
    {
        myCharacterController = GetComponent<CharacterController2D>();
        //myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        //myAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        //if()

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }

        //Debug.Log(horizontalMove);


        //Debug.Log(jumping);
    }

    private void FixedUpdate()
    {
        //Debug.Log(jumping);
        myCharacterController.Move(horizontalMove * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }

}  