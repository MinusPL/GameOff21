using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPCController : MonoBehaviour
{
    [Header("Data")]
    public string npcName;
    [Header("Object references")]
    public TextMeshPro nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = npcName;
    }

    // Update is called once per frame
    void Update()
    {
        //Fix for text rotation in relation to camera. This should be done via shader, but should work fine for preview
        transform.rotation = Camera.main.transform.rotation;
    }
}
