using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject button;
    public GameObject buttonParent;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            CreateNewItem(i);
        }
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count;i++)
        {
            if(itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = inventory.Container[i].item.itemName;
                itemsDisplayed[inventory.Container[i]].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
            }
            else
            {
                CreateNewItem(i);
            }
        }
    } 
    public void CreateNewItem(int i)
    {
        GameObject newButton = Instantiate(button) as GameObject;
        newButton.transform.SetParent(buttonParent.transform,false);
        newButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = inventory.Container[i].item.itemName;
        newButton.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
        //newButton.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
        if(inventory.Container[i].item.type == ItemType.Equipment)
        {
            newButton.GetComponent<Button>().onClick.AddListener(inventory.Container[i].item.Use());
        }
        itemsDisplayed.Add(inventory.Container[i], newButton);
    }
}
