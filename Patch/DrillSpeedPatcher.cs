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
            float newProg =  (float) (__instance.DrillTicks + Math.Floor(__instance.DrillTicks * multiplierSetting));
            __instance.DrillTicks = newProg;
        }

        // Prefix version, test only (don't use)
        //static bool DrillPatchPrefix(float prog, CompOilDerrick __instance)
        //{
        //    if (__instance.fuelComp == null)
        //    {
        //        Log.ErrorOnce("OilWell def is missing a required CompRefuelable for steel, a mod probably stripped it from the building.", 1003003025);
        //        return false;
        //    }
        //    // simple calculation
        //    float settingsMultiplier = DrillModInit.settings.drillSpeedMultiplier;
        //    float decimalMultiplier = settingsMultiplier / 100;
        //    float newProg = prog * decimalMultiplier;
        //    // __instance.DrillTicks += prog; <--- original
        //    __instance.DrillTicks += newProg;
        //    if (__instance.DrillTicks >= (float)__instance.Props.TicksPerSteel)
        //    {
        //        __instance.DrillTicks = 0f;
        //        __instance.pipeUsed++;
        //        if (!(__instance.fuelComp.Fuel >= (float)(__instance.Props.SteelCost - __instance.pipeUsed)))
        //        {
        //            __instance.fuelComp.ConsumeFuel(1f);
        //        }
        //    }
        //    __instance.LastDrilledTick = Find.TickManager.TicksGame;

        //    return false;
        //}
    }
}
