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
using RimeDrillSpeedMultiplier.HarmonyRelated;
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
            Listing_Standard modUI = new Listing_Standard();
            modUI.Begin(inRect);
            modUI.CheckboxLabeled(UIInfo.ENABLE_CHECKBOX_LABEL, ref settings.enableDrillConfiguration, UIInfo.ENABLE_CHECKBOX_TOOLTIP_TEXT);
            modUI.GapLine();
            modUI.CheckboxLabeled(UIInfo.ENABLE_CONSISTENT_PROGRESSION_LABEL, ref settings.consistentDrillConfiguration, UIInfo.ENABLE_CONSISTENT_PROGRESSION_TOOLTIP);
            modUI.LabelDouble(UIInfo.BASE_FACTOR_CONSISTENT_LABEL, $"{settings.consistentSpeedBaseFactor}");
            settings.consistentSpeedBaseFactor = (float)Math.Floor(modUI.Slider(settings.consistentSpeedBaseFactor, 1f, 100f));
            modUI.SubLabel(UIInfo.CONSISTENT_PROGRESSION_SUBLABEL, 1.5f);
            modUI.GapLine();
            modUI.LabelDouble(UIInfo.SLIDER_TEXT, $"{settings.drillSpeedMultiplier}%");
            settings.drillSpeedMultiplier = (float)Math.Floor(modUI.Slider(settings.drillSpeedMultiplier, 1f, 1000f));
            modUI.SubLabel(UIInfo.SUB_LABEL, 1.5f);
            modUI.GapLine();
            if (modUI.ButtonText(UIInfo.RESET_BTN_TEXT))
            {
                settings.drillSpeedMultiplier = 100f;
            }
            modUI.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            // preventing duplicate patching
            if (settings.enableDrillConfiguration == true)
            {
                if (settings.previousEnabledDrillConfig == true)
                {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_ALREADY_ACTIVE);
                }
                else
                {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_ACTIVE);
                    PatchManager.ApplyPatch();
                }
            }

            if (settings.enableDrillConfiguration == false)
            {
                if (settings.previousEnabledDrillConfig == false)
                {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_ALREADY_INACTIVE);
                }
                else
                {
                    Log.Message(ModLogMessages.MESSAGE_PATCH_INACTIVE);
                    PatchManager.WithdrawPatch();
                }
            }

            settings.previousEnabledDrillConfig = settings.enableDrillConfiguration;
        }

        public override string SettingsCategory()
        {
            return UIInfo.WINDOW_TITLE;
        }
    }
}
