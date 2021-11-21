using UnityEngine;

public class Player : MonoBehaviour
{
    public float statATK = 10;
    public float statDEF = 10;
    public float statHP = 100;
    public float statCurHP = 100;
    public ItemObject equipedWeapon;
    public ItemObject equipedArmor;
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other) 
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item,1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    public void Equip(ItemObject eqPiece)
    {
    }
}
