using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimeDrillSpeedMultiplier.HarmonyInit;
using RimeDrillSpeedMultiplier.Patch;
using Rimefeller;
using Verse;

namespace RimeDrillSpeedMultiplier
{
    public class PatchManager
    {
        private static MethodInfo patch = AccessTools.Method(typeof(DrillSpeedPatcher), "DrillPatch");
        public static void Apply()
        {

            ModInfo.modHarmony.Patch(AccessTools.Method(typeof(CompOilDerrick), "Drill", new Type[] {typeof(float)}), patch);
           
        }
    }
}
