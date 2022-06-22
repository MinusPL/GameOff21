using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class UIController : MonoBehaviour
{
    [Header("UI elements")]
    public GameObject dialog;
    
    [Header("Other objects references")]
    public CameraController freeLookCam;

    private GameObject player;
    private float timer = 0.0f;
    private bool uiEnabled = false;
	// Start is called before the first frame update
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
   //     if (uiEnabled)
   //     {
   //         timer += Time.deltaTime;
   //         if (timer > 5.0f)
			//{
   //             uiEnabled = false;
   //             DisableUI();
   //             timer = 0.0f;
			//}
   //     }
    }

    public void EnableUI()
	{
        player.GetComponent<PlayerInput>().actions.Disable();
        freeLookCam.DisableCamMovement();
        uiEnabled = true;
    }

    public void DisableUI()
	{
        player.GetComponent<PlayerInput>().actions.Enable();
        dialog.SetActive(false);
        uiEnabled = false;
        freeLookCam.EnableCamMovement();
    }

    public void EnableDialogueUI()
	{
        player.GetComponent<PlayerInput>().actions.Disable();
        dialog.SetActive(true);
        uiEnabled = true;
        freeLookCam.DisableCamMovement();
    }
}
