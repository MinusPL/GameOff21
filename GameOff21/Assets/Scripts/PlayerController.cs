using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

//TODO ADD COMBAT
public class PlayerController : MonoBehaviour
{
    public enum player_states
	{
        IDLE,
        MOVING,
	    RUNNING,
        JUMP_START,
        FALLING
    }

    public GameObject camTarget;
    public Animator animator;
    public float walkspeed;
    public float runningSpeed;
    [Header("Camera Stuff")]
    public CinemachineFreeLook freeLookCam;
    public float rotateSmoothTime = 0.1f;
    public float jumpSpeed = 1.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;
    public float distanceStep = 0.5f;
    public float currentDistance = 5.0f;
    [Header("Character Sizes")]
    public float colliderHeightNormal = 2.0f;
    public float colliderHeightJump = 1.2f;

    private Vector2 movement;
    public Vector3 velocity;
    private float smoothAngle;

    public float targetDistance = 5.0f;
    private float targetDistanceVelocity;

    private bool isRunning = false;
    public bool onGround = true;

    private Rigidbody rb;

    public player_states state = player_states.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void OnMove(InputValue value)
	{
        movement = value.Get<Vector2>();
	}

    private void Update()
    {
        if (targetDistance != currentDistance)
        {
            currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref targetDistanceVelocity, 0.1f);
            freeLookCam.m_Orbits[0].m_Height = currentDistance;
            freeLookCam.m_Orbits[1].m_Radius = currentDistance;
            freeLookCam.m_Orbits[2].m_Height = -currentDistance;
        }
    }

	private void FixedUpdate()
	{
        player_states prevState = state;
        Vector3 dir = new Vector3(movement.x, 0.0f, movement.y).normalized;
        if (state != player_states.FALLING && state != player_states.JUMP_START)
        {
            float speed = isRunning ? runningSpeed : walkspeed;
            if (dir.magnitude > 0.01f)
            {
                animator.SetBool("Moving", true);
                animator.SetBool("Running", isRunning);
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + camTarget.transform.eulerAngles.y;
                float smoothTarget = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothAngle, rotateSmoothTime);
                transform.rotation = Quaternion.Euler(0f, smoothTarget, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                moveDir = moveDir.normalized * speed;
                velocity = new Vector3(moveDir.x, 0, moveDir.z);
            }
            else
            {
                animator.SetBool("Moving", false);
                animator.SetBool("Running", false);
                velocity = Vector3.zero;
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            }
        }

        if(!IsGrounded())
		{
            state = player_states.FALLING;
		}
        else
		{
            if (state == player_states.FALLING)
            {
                state = player_states.IDLE;
                rb.velocity = Vector3.zero;
                if (dir.magnitude <= 0.01f)
                {
                    velocity = Vector3.zero;
                    
                }
			}
		}

        if (dir.magnitude > 0.01f)
        {
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        }
        animator.SetBool("OnGround", IsGrounded());
    }

    public void OnRun(InputValue value)
	{
        isRunning = value.isPressed;
	}

    public void OnJump(InputValue value)
	{
        if (state != player_states.JUMP_START && state != player_states.FALLING)
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            state = player_states.JUMP_START;
        }
    }

    public void OnZoom(InputValue value)
	{
        Debug.Log(value.Get<Vector2>());
        Vector2 zoomDirection = value.Get<Vector2>().normalized;
        if(zoomDirection.y < 0f)
		{
            targetDistance += distanceStep;
            if (targetDistance > maxDistance) targetDistance = maxDistance;
		}
        else if(zoomDirection.y > 0f)
		{
            targetDistance -= distanceStep;
            if (targetDistance < minDistance) targetDistance = minDistance;
		}
    }
	public bool IsGrounded()
	{
        bool check = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.2f);
        return check;
    }
}
