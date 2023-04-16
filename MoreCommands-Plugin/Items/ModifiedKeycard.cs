using FacilityManager;
using FacilityManager.Behaviours;
using FacilityManager.Server;
using Mirror;
using UnityEngine;

namespace MoreCommands_Plugin.Items
{
    public class ModifiedKeycardMetadata : ItemMetadata
    {
        public bool IsItemDefined => ItemToSpawn != -1;

        public int ItemToSpawn = -1;
    }

    public class ModifiedKeycard : Keycard
    {
        public ModifiedKeycard(short varaintId) : base(varaintId)
        {
        }

        public override void OnUse(HumanPlayer player, ItemUseType useType)
        {
            base.OnUse(player, useType);
            var metadata = GetMetadata<ModifiedKeycardMetadata>(player);

            if (metadata.IsItemDefined)
            {
                GameObject prefab = Context.ItemRegistry.GetItemInfo(metadata.ItemToSpawn).Prefab;

                GameObject spawnedObject = Object.Instantiate(prefab, player.transform.position + Vector3.up, Quaternion.identity);
                NetworkServer.Spawn(spawnedObject);
            }
        }

        public override ItemMetadata CreateMetadata()
        {
            return new ModifiedKeycardMetadata();
        }
    }
}
