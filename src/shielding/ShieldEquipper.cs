using System.Collections.Generic;

namespace Ratzu.AutoShield;

public static class ShieldEquipper
{
    public static void MaybeEquipShield(Humanoid humanoid, bool oneHandedWeaponWasEquipped)
    {
        if (!oneHandedWeaponWasEquipped || humanoid.GetLeftItem() != null)
        {
            return;
        }
        List<ItemDrop.ItemData> items = humanoid.m_inventory.GetAllItems();
        ItemDrop.ItemData shield = items.Find(item => item.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Shield);
        if (shield == null) {
            return;
        }
        humanoid.EquipItem(shield, false);
    }
}
