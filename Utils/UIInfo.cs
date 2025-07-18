using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeDrillSpeedMultiplier.Utils
{
    public class UIInfo
    {
        public static readonly string ENABLE_CHECKBOX_LABEL = "Enable drill progress multiplier";
        public static readonly string ENABLE_CHECKBOX_TOOLTIP_TEXT = "Enables or disables this mod.";
        public static readonly string ENABLE_CONSISTENT_PROGRESSION_LABEL = "Enable consistent drilling progression";
        public static readonly string ENABLE_CONSISTENT_PROGRESSION_TOOLTIP = "The drill speed is tied to your pawn's mining speed, which is also linked to other factors such as global work speed, mining skill and other health factors.\n"
        + "\nWhen disabled, the progression varies pawn by pawn due to differences in their stats. It could be slower or it could be fast, depending on your pawn stats.\n"
        + "\nWhen enabled, the progression will be consistent throughout regardless of their stat differences.";
        public static readonly string CONSISTENT_PROGRESSION_SUBLABEL = "Only takes effect if consistent drilling progression is enabled.";
        public static readonly string BASE_FACTOR_CONSISTENT_LABEL = "Consistent progression base factor";
        public static readonly string SLIDER_TEXT = "Multiplier";
        public static readonly string WINDOW_TITLE = "Rimefeller Drill Progress Multiplier";
        public static readonly string RESET_BTN_TEXT = "Reset multiplier";
        public static readonly string SUB_LABEL = "Default is 100%";

    }
}
