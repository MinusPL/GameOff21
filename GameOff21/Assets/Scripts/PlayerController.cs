using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject camTarget;
    public Animator animator;
    public CharacterController controller;
    public float walkspeed;
    public float runningSpeed;
    [Header("Camera Stuff")]
    public float pitchMin = 0.0f;
    public float pitchMax = 0.0f;
    public float cameraSensitivity;
    public float rotateSmoothTime = 0.1f;
    private Vector2 movement;
    private Vector2 look;
    private float pitch;
    private float smoothAngle;

    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void OnMove(InputValue value)
	{
        movement = value.Get<Vector2>();
	}

	private void Update()
	{
        float speed = isRunning ? runningSpeed : walkspeed;
        Vector3 dir = new Vector3(movement.x, 0.0f, movement.y).normalized;
        if(dir.magnitude > 0.01f)
		{
            animator.SetBool("Moving", true);
            animator.SetBool("Running", isRunning);
            //Move Player
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + camTarget.transform.eulerAngles.y;
            float smoothTarget = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothAngle, rotateSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothTarget, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
		{
            animator.SetBool("Moving", false);
            animator.SetBool("Running", false);
        }
    }

    public void OnRun(InputValue value)
	{
        isRunning = value.isPressed;
	}


}
