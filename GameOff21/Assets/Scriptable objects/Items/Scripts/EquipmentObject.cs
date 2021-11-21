using UnityEngine;
public enum EquipmentSubType
{
    Weapon,
    Armor,
    Misc
}
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public EquipmentSubType subType;
    public float atkBonus;
    public float defBonus;
    private bool isEquiped = false;
    public void Awake()
    {
        type=ItemType.Equipment;
    }
    override public void Use()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().statATK=20;
    }
}
