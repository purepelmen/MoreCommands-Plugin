using FacilityManager.Behaviours;
using FacilityManager.Server;

namespace MoreCommands_Plugin.Commands
{
    public class AddSpeedCommand : Command
    {
        public override string Description => "Adds speed to a player (addspeed <member> <add_value>).";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            Member targetMember = reader.ReadMember(commandContext.Sender);
            int addValue = reader.ReadInt();

            Player player = Context.PlayerSpawner.GetPlayer(targetMember);
            player.Movement.AddModifier(new PlayerMovement.Modifier()
            {
                RelativeSpeed = addValue
            });
        }
    }
}
