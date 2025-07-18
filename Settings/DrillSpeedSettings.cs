using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimeDrillSpeedMultiplier
{

    public class DrillSpeedSettings : ModSettings
    {
        public bool enableDrillConfiguration = true;
        public bool consistentDrillConfiguration = true;
        public float consistentSpeedBaseFactor = 1f;
        public float drillSpeedMultiplier = 100f; // In percentage
        public bool previousEnabledDrillConfig = true;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref enableDrillConfiguration, "enableDrillConfiguration", defaultValue: true);
            Scribe_Values.Look(ref drillSpeedMultiplier, "drillSpeedMultiplier", defaultValue: 100f);
            Scribe_Values.Look(ref consistentDrillConfiguration, "consistentDrillConfiguration", true);
            Scribe_Values.Look(ref consistentSpeedBaseFactor, "consistentSpeedBaseFactor", 1f);
            base.ExposeData();
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                previousEnabledDrillConfig = enableDrillConfiguration;
            }
        }
    }
}
