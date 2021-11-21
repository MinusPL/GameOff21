using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    virtual public void Use()
    {

    }
}