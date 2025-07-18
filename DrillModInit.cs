using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using HarmonyLib;
using UnityEngine;
using RimeDrillSpeedMultiplier.Patch;
using Rimefeller;
using System.Reflection;
using RimeDrillSpeedMultiplier.HarmonyInit;
using RimeDrillSpeedMultiplier.Utils;

namespace RimeDrillSpeedMultiplier
{
    public class DrillModInit : Mod
    {
        public static DrillSpeedSettings settings;
        
        public DrillModInit(ModContentPack content) : base(content)
        {
            ModInfo.modHarmony = new Harmony(ModInfo.HarmonyID);
            settings = this.GetSettings<DrillSpeedSettings>();
            Log.Message(ModLogMessages.MESSAGE_INIT);
            if (settings.enableDrillConfiguration)
            {
                Log.Message(ModLogMessages.MESSAGE_PATCH_ACTIVE);
                PatchManager.ApplyPatch();
            }
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled(UIInfo.ENABLE_CHECKBOX_LABEL, ref settings.enableDrillConfiguration, UIInfo.ENABLE_CHECKBOX_TOOLTIP_TEXT);
            listingStandard.Label(UIInfo.SLIDER_TEXT);
            settings.drillSpeedMultiplier = (float) Math.Floor(listingStandard.SliderLabeled($"{settings.drillSpeedMultiplier}%", settings.drillSpeedMultiplier, 100f, 1000f));
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings()
        {
            base.WriteSettings();

            if (settings.enableDrillConfiguration == true)
            {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_ACTIVE);
                    PatchManager.ApplyPatch();
            }

            if (settings.enableDrillConfiguration == false)
            {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_INACTIVE);
                    PatchManager.WithdrawPatch();
            }
        }

        public override string SettingsCategory()
        {
            return "Rimefeller Drill Speed Multiplier";
        }
    }
}
