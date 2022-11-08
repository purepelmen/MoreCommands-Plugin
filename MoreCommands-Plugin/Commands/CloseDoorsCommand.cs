using FacilityManager.Server;
using FacilityManager.World;

namespace MoreCommands_Plugin.Commands
{
    public class CloseDoorsCommand : Command
    {
        public override string Description => "Closes all the doors in the facility.";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
            {
                door.Close();
            }
        }
    }
}
