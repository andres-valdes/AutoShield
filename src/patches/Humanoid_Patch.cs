using HarmonyLib;

namespace Ratzu.AutoShield;

public class Humanoid_Patch
{
    [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.EquipItem))]
    public static class Humanoid_EquipItem_EquipShieldIfNewlyEquippedItemIsOneHanded
    {
        public static void Postfix(Humanoid __instance, ref bool __result, ItemDrop.ItemData item)
        {
            if (__result && item.m_shared.m_itemType == ItemDrop.ItemData.ItemType.OneHandedWeapon)
            {
                ShieldEquipper.MaybeEquipShield(__instance, __result);
            }
        }
    }
}
