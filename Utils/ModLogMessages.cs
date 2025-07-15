using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeDrillSpeedMultiplier
{
    public static class ModLogMessages
    {
        private static readonly string messageTag = "[Rimefeller Drill Speed Multiplier]";
        public static readonly string MESSAGE_INIT = $"{messageTag} Mod is now primed.";
        public static readonly string MESSAGE_PATCH_ACTIVE = $"{messageTag} Mod is activated.";
        public static readonly string MESSAGE_PATCH_INACTIVE = $"{messageTag} Mod is deactivated.";
        public static readonly string MESSAGE_PATCH_ALREADY_ACTIVE = $"{messageTag} Mod is already activated, skipping patching.";
        public static readonly string MESSAGE_PATCH_ALREADY_INACTIVE = $"{messageTag} Mod is already deactivated, skipping unpatching.";
        
    }
}
