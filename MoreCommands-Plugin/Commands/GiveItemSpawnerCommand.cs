using FacilityManager;
using FacilityManager.Behaviours;
using FacilityManager.Server;

namespace MoreCommands_Plugin.Commands
{
    public class GiveItemSpawnerCommand : Command
    {
        public override string Description => "Gives an item spawner (itemspawner <item_id>).";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            int itemId = reader.ReadInt();
            if (Context.ItemRegistry.GetItemInfo(itemId) == null)
            {
                commandContext.ResponseError("Item id not found.\n");
            }

            Player player = Context.PlayerSpawner.GetPlayer(commandContext.Sender);
            if (player.TryGetComponent(out HumanPlayer humanPlayer))
            {
                if (humanPlayer.Inventory.HasFreeSpace == false)
                    commandContext.ResponseError("You don't have free space in inventory.\n");

                ItemData itemData = new ItemData();
                itemData.SetInt("item_to_spawn", itemId);

                humanPlayer.Inventory.AddItem(Context.ItemRegistry.GetItemInfo(2), itemData);
                commandContext.Response("Item spawner was added to your inventory.\n");

                return;
            }

            commandContext.ResponseError("Your player object doesn't have inventory.\n");
        }
    }
}
