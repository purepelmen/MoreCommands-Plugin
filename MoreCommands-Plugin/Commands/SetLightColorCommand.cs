using FacilityManager.Server;
using FacilityManager.World;
using System;
using UnityEngine;

namespace MoreCommands_Plugin.Commands
{
    public class SetLightColorCommand : Command
    {
        public override string Description => "Sets light color in the facility (lightcolor <color_hex>).";

        public override void Execute(CommandContext commandContext, CommandReader reader)
        {
            string colorHex = reader.ReadText();

            Color color = ConvertHexStringToColor(commandContext, colorHex);
            Context.GetController<FacilityPower>().RpcSetColor(color);
        }

        private Color ConvertHexStringToColor(CommandContext commandContext, string colorHex)
        {
            if (colorHex.Length != 6)
            {
                commandContext.ResponseError("Hex number must consist from 6 characters 0-9 A-F, without '#' character.\n");
            }

            return new Color(
                Convert.ToInt32(colorHex.Substring(0, 2), 16) / 255f,
                Convert.ToInt32(colorHex.Substring(2, 2), 16) / 255f,
                Convert.ToInt32(colorHex.Substring(4, 2), 16) / 255f);
        }
    }
}
