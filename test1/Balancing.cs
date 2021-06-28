using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using System.Reflection.Emit;
using PulsarPluginLoader.Patches;

namespace Randomizer
{
    [HarmonyPatch(typeof(PLHull), MethodType.Constructor, new Type[] { typeof(EHullType), typeof(int) })]
    class AncientHullPatch
    {       
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> targetSequence = new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLHull),"m_Defense")),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldc_I4_M1),
            };
            List<CodeInstruction> patchSequence = new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLHull),"m_Defense")),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldc_I4, 0x61A8),

            };
            return HarmonyHelpers.PatchBySequence(Instructions, targetSequence, patchSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
        }
    }
    [HarmonyPatch(typeof(PLHull), MethodType.Constructor, new Type[] { typeof(EHullType), typeof(int) })]
    class HullPricePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[173].operand = 0xAFC8;
            instructionsList[199].operand = 0xDAC;
            instructionsList[274].operand = 0x13880;
            instructionsList[303].operand = 0x9470;
            return instructionsList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLReactor), MethodType.Constructor, new Type[] { typeof(EReactorType), typeof(int) })]
    class ReactorPricePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[272].operand = 0x249F0;
            instructionsList[194].operand = 0x4650;
            return instructionsList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLSporeTurret), MethodType.Constructor, new Type[] { typeof(int), typeof(int) })]
    class SporeTurretPricePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[15].operand = 0xC350;
            instructionsList[19].operand = 10000f;
            instructionsList[25].operand = 26f;
            return instructionsList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLRailgunTurretAncient), MethodType.Constructor, new Type[] { typeof(int), typeof(int) })]
    class AncientRailgunPricePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[17].operand = 0x2EE0;
            return instructionsList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLInertiaThruster), MethodType.Constructor, new Type[] { typeof(EInertiaThrusterType), typeof(int) })]
    class InertiaPricePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[89].operand = 0x7530;
            instructionsList[66].operand = 0x88B8;
            return instructionsList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLCorruptedLaserTurret), MethodType.Constructor, new Type[] { typeof(int), typeof(int) })]
    class AncientLaserPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
        {
            List<CodeInstruction> instructionsList = Instructions.ToList();
            instructionsList[11].operand = 600f;
            instructionsList[14].operand = 15f;
            instructionsList[20].operand = 12000f;
            return instructionsList.AsEnumerable();
        }
    }
}
