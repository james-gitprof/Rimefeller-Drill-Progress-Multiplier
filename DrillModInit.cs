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

namespace RimeDrillSpeedMultiplier
{
    public class DrillModInit : Mod
    {
        public static DrillSpeedSettings settings;
        
        public DrillModInit(ModContentPack content) : base(content)
        {
            ModInfo.modHarmony = new Harmony("Luminiel.RimeDrillSpeedMultiplier");
            settings = this.GetSettings<DrillSpeedSettings>();
            Log.Message("Drill speed multiplier mod is primed.");
            if (settings.enableDrillConfiguration)
            {
                Log.Message("[Rimefeller Drill Speed Multiplier] Added multiplier on supervising drill work");
                //harmony.Patch(typeof(CompOilDerrick).GetMethod("Drill"), prefix: new HarmonyMethod(typeof(DrillSpeedPatcher).GetMethod("Prefix")));
                MethodInfo patch = AccessTools.Method(typeof(DrillSpeedPatcher), "DrillPatchPostfix");
                ModInfo.modHarmony.Patch(AccessTools.Method(typeof(CompOilDerrick), "Drill", new Type[] {typeof(float)}), new HarmonyMethod(patch));
            }
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Enable drill speed multiplier", ref settings.enableDrillConfiguration, "Whether the mod should add a multiplier on supervising drill work");
            listingStandard.Label("Drill speed multiplier:");
            settings.drillSpeedMultiplier = (float) Math.Floor(listingStandard.SliderLabeled($"{settings.drillSpeedMultiplier}%", settings.drillSpeedMultiplier, 100f, 1000f));
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
        }

        public override string SettingsCategory()
        {
            return "Rimefeller Drill Speed Multiplier";
        }
    }
}
