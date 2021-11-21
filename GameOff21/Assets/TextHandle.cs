using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextHandle : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemAmount;
    public TextMeshProUGUI returnName()
    {
        return itemName;
    }
    public TextMeshProUGUI returnAmount()
    {
        return itemAmount;
    }

}
