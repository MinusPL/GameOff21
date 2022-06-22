using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControler2 : MonoBehaviour
{
    //Public fields
    public float jumpHeight;
    public float gravity;


    //velocities
    float _verticalVelocity;
    private Vector2 movement;
    private Animator animator;
    private CharacterController cc;

    Vector3 velocity;

    //private flags to tell if player is in given state
    bool isSprinting = false;
    bool grounded;

	private void Awake()
	{
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JumpAndGravity();
        //GroundedCheck();
        Move();
    }

	private void FixedUpdate()
	{
		//if(isJumping)
		//{
  //          velocity.y -= gravity * Time.fixedDeltaTime;
  //          cc.Move(velocity * Time.fixedDeltaTime);
  //          isJumping = !cc.isGrounded;
		//}
	}

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnRun(InputValue value)
    {
        animator.SetBool("Running", value.isPressed);
        isSprinting = value.isPressed;
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;
        velocity.y = gravity * Time.deltaTime;

        cc.Move(velocity);
    }

    public void OnJump(InputValue value)
    {
  //      if(!isJumping)
		//{
  //          isJumping = true;
  //          velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
		//}
    }

    private void JumpAndGravity()
	{

	}

    private void Move()
	{

	}
}
