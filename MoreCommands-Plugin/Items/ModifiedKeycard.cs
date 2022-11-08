using FacilityManager;
using FacilityManager.Behaviours;
using FacilityManager.Server;
using Mirror;
using UnityEngine;

namespace MoreCommands_Plugin.Items
{
    public class ModifiedKeycard : Keycard
    {
        public ModifiedKeycard(short varaintId) : base(varaintId)
        {
        }

        public override void OnUse(HumanPlayer player, ItemUseType useType)
        {
            base.OnUse(player, useType);
            ItemData itemData = GetItemData(player);

            if (itemData.GetInt("item_to_spawn", -1) == -1) return;
            GameObject prefab = Context.ItemRegistry.GetItemInfo(itemData.GetInt("item_to_spawn")).Prefab;

            GameObject spawnedObject = Object.Instantiate(prefab, player.transform.position + Vector3.up, Quaternion.identity);
            NetworkServer.Spawn(spawnedObject);
        }
    }
}
