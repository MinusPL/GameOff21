using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    private List<Interactable> interactionOptions;

    [Header("UI Elements")]
    public UIController uiController;
    public GameObject interactionText;

    [Header("DEBUG")]
    public TextMeshProUGUI numOfInteractables;

	public void Awake()
	{
        interactionOptions = new List<Interactable>();
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactionText.SetActive(interactionOptions.Count > 0);
        numOfInteractables.text = $"Interactables active: {interactionOptions.Count}";
    }

    public void EnableInteraction(Interactable interactable)
	{
        interactionOptions.Add(interactable);
	}

    public void DisableInteraction(Interactable interactable)
	{
        interactionOptions.Remove(interactable);
	}

    public void OnInteract(InputValue value)
    {
        Interactable obj = interactionOptions.FirstOrDefault();
        if (obj != null)
        {
            if (obj.interactionType == InteractionType.TALK)
            {
                uiController.EnableDialogueUI();
            }
        }
        //obj.Interact();
        
    }
}
