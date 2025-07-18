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
        private static readonly string PATCH_METHOD_NAME = "DrillPatchPostfix";
        private static readonly string ORIGINAL_METHOD_NAME = "Drill";
        private static MethodInfo patch = AccessTools.Method(typeof(DrillSpeedPatcher), PATCH_METHOD_NAME);
        private static MethodInfo original = AccessTools.Method(typeof(CompOilDerrick), ORIGINAL_METHOD_NAME, new Type[] { typeof(float) });
        public static void ApplyPatch()
        {
            ModInfo.modHarmony.Patch(original, postfix: patch);
        }

        public static void WithdrawPatch()
        {
            ModInfo.modHarmony.Unpatch(original, patch);
        }
    }
}
