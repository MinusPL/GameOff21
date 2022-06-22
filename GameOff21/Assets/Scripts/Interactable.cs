using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InteractionType
{
    TALK,
    TRIGGER,
    PICKUP
}

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    [Header("Intercation options")]
    public InteractionType interactionType;
    //This might need some other work, for now should be enough.
    public int id;

    // Start is called before the first frame update

    private bool active = false;
    private InteractionManager interactionManager;

    void Start()
    {
        interactionManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<InteractionManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            active = true;
            interactionManager.EnableInteraction(this);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            active = false;
            interactionManager.DisableInteraction(this);
        }
    }

    public void Interact()
	{

	}
}