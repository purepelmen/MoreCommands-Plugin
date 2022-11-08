using FacilityManager;
using FacilityManager.Behaviours;
using FacilityManager.Server;
using Mirror;
using System.Collections;
using UnityEngine;

namespace MoreCommands_Plugin.Commands
{
    public class SpawnItemCommand : Command
    {
        public override string Description => "Spawns an item at player position (spawnitem <member> <item_id> <amount>).";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            Member member = reader.ReadMember(commandContext.Sender);
            int itemId = reader.ReadInt();
            int amount = reader.ReadInt();

            ItemInfo itemInfo = Context.ItemRegistry.GetItemInfo(itemId);
            if (itemInfo == null)
            {
                commandContext.ResponseError("Item id not found.\n");
            }

            Player player = Context.PlayerSpawner.GetPlayer(member);
            if (player == null)
            {
                commandContext.ResponseError("Specified member is not spawned (waiting as spectator or waiting for server start).\n");
            }

            player.StartCoroutine(SpawnItem(itemInfo, player.transform.position + Vector3.up, amount));
        }

        private IEnumerator SpawnItem(ItemInfo itemInfo, Vector3 position, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject spawnedObject = Object.Instantiate(itemInfo.Prefab, position, Quaternion.identity);
                NetworkServer.Spawn(spawnedObject);
                
                yield return null;
            }
        }
    }
}
