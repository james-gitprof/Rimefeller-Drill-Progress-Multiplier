using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Rimefeller;
using Verse;

namespace RimeDrillSpeedMultiplier.Patch
{
    [HarmonyPatch(typeof(CompOilDerrick), nameof(CompOilDerrick.Drill), new Type[] { typeof(float)})]
    public class DrillSpeedPatcher
    {
        static void DrillPatchPostfix(float prog, CompOilDerrick __instance)
        {
            float multiplierSetting = DrillModInit.settings.drillSpeedMultiplier;
            float decimalMultiplier = multiplierSetting / 100;
            decimalMultiplier = decimalMultiplier == 1 ? 0 : decimalMultiplier;
            float newProg =  (float) (__instance.DrillTicks + Math.Floor(__instance.DrillTicks * decimalMultiplier));
            __instance.DrillTicks = newProg;
        }
    }
}
