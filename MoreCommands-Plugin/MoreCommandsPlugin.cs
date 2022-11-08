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
            var commandRegistry = context.GetController<CommandRegistry>();

            commandRegistry.Register("addspeed", new AddSpeedCommand());
            commandRegistry.Register("addjump", new AddJumpHeightCommand());
            commandRegistry.Register("opendoors", new OpenDoorsCommand());
            commandRegistry.Register("closedoors", new CloseDoorsCommand());
            commandRegistry.Register("itemspawner", new GiveItemSpawnerCommand());
            commandRegistry.Register("spawnitem", new SpawnItemCommand());
            commandRegistry.Register("lightcolor", new SetLightColorCommand());

            var itemRegistry = context.GetController<ItemRegistry>();
            itemRegistry.RegisterItem(2, new ModifiedKeycard(2));
        }
    }
}
