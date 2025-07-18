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
            float curProg = prog;
            if (DrillModInit.settings.consistentDrillConfiguration == true)
            {
                curProg = DrillModInit.settings.consistentSpeedBaseFactor;
            }
            float multiplierSetting = DrillModInit.settings.drillSpeedMultiplier;
            float decimalMultiplier = multiplierSetting / 100;
            Log.Message($"DrillTicks: {__instance.DrillTicks}, decimalMult: {decimalMultiplier}, prog: {curProg}");
            // undo the previous
            __instance.DrillTicks -= prog;
            // then replace it with the new one
            __instance.DrillTicks += (curProg * decimalMultiplier);
        }
    }
}
