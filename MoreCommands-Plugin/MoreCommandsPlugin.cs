using FacilityManager;
using FacilityManager.PluginApi;
using FacilityManager.Server;
using MoreCommands_Plugin.Commands;
using MoreCommands_Plugin.Items;

namespace MoreCommands_Plugin
{
    [FoundablePlugin]
    public class MoreCommandsPlugin : Plugin
    {
        public override PluginInfo GetInfo()
        {
            return new PluginInfo()
            {
                ApiCompatibilityLevel = Api.CompatibilityLevel,
                Name = "More Commands Plugin"
            };
        }

        public override void Initialize(GameContext context)
        {
            var commandRegistry = context.Get<CommandRegistry>();

            commandRegistry.Register("addspeed", new AddSpeedCommand());
            commandRegistry.Register("addjump", new AddJumpHeightCommand());
            commandRegistry.Register("opendoors", new OpenDoorsCommand());
            commandRegistry.Register("closedoors", new CloseDoorsCommand());
            commandRegistry.Register("itemspawner", new GiveItemSpawnerCommand());

            var itemRegistry = context.Get<ItemRegistry>();
            itemRegistry.RegisterItem(2, new ModifiedKeycard(1));
        }
    }
}
