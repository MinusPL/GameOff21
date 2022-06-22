using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float xMaxSpeed;
    public float yMaxSpeed;
    [SerializeField]
    private CinemachineFreeLook freeLookCam;
    // Start is called before the first frame update
    
    void Awake()
	{
        freeLookCam = gameObject.GetComponent<CinemachineFreeLook>();
	}
    
    void Start()
    {
        freeLookCam.m_XAxis.m_MaxSpeed = xMaxSpeed;
        freeLookCam.m_YAxis.m_MaxSpeed = yMaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCamMovement()
	{
        freeLookCam.m_XAxis.m_MaxSpeed = 0;
        freeLookCam.m_YAxis.m_MaxSpeed = 0;
	}

    public void EnableCamMovement()
    {
        freeLookCam.m_XAxis.m_MaxSpeed = xMaxSpeed;
        freeLookCam.m_YAxis.m_MaxSpeed = yMaxSpeed;
    }
}
