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
        public bool enableDrillConfiguration = false;
        public bool previousIsDrillConfigEnabled = false;
        public float drillSpeedMultiplier = 100f; // In percentage

        public override void ExposeData()
        {
            Scribe_Values.Look(ref enableDrillConfiguration, "enableDrillConfiguration");
            Scribe_Values.Look(ref drillSpeedMultiplier, "drillSpeedMultipliter");
            base.ExposeData();
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                previousIsDrillConfigEnabled = enableDrillConfiguration;
            }
        }
    }
}
