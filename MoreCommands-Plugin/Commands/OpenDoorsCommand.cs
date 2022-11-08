using FacilityManager.Server;
using FacilityManager.World;

namespace MoreCommands_Plugin.Commands
{
    public class OpenDoorsCommand : Command
    {
        public override string Description => "Opens all the doors in the facility.";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
            {
                door.Open();
            }
        }
    }
}
