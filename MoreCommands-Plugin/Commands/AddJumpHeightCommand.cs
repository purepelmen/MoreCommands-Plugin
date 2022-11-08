using FacilityManager.Behaviours;
using FacilityManager.Server;

namespace MoreCommands_Plugin.Commands
{
    public class AddJumpHeightCommand : Command
    {
        public override string Description => "Adds jump to a player (addjump <member> <add_value>).";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            Member targetMember = reader.ReadMember(commandContext.Sender);
            int addValue = reader.ReadInt();

            Player player = Context.PlayerSpawner.GetPlayer(targetMember);
            player.Movement.AddModifier(new PlayerMovement.Modifier()
            {
                RelativeJumpHeight = addValue
            });
        }
    }
}
