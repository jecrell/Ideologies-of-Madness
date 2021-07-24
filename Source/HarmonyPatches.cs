using HarmonyLib;
using RimWorld;
using RimWorld.BaseGen;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;

namespace IdeologiesOfMadness
{
    /// <summary>
    /// Brrainz are delicious.
    /// </summary>
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("Jecrell.IdeologiesOfMadness");
            string lastPatch = "";
            try
            {
                lastPatch = "ExecutionUtility.DoExecutionByCut";
                {
                    //Toils_Tend
                    Type type = typeof(ExecutionUtility);

                    //Patch: ExecutionUtility.DoExecutionByCut as Prefix
                    harmony.Patch(
                        type.GetMethod("DoExecutionByCut"),
                        new HarmonyMethod(typeof(HarmonyPatches).GetMethod(nameof(Patch_ExecutionUtility_DoExecutionByCut))),
                        null);
                }
            }
            catch (Exception exception)
            {
                Log.Error($"Last patch that went wrong is: {lastPatch}. Exception message: {exception.Message}");
            }

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static bool Patch_ExecutionUtility_DoExecutionByCut(Pawn executioner, Pawn victim, int bloodPerWeight, bool spawnBlood)
        {
            if (victim == null) return true;

            //Sacrifices, strangely enough, do not have any blood.
            if (bloodPerWeight == 0 && spawnBlood == false)
            {
                if (victim?.RaceProps?.Animal == true)
                    SacrificeUtility.DoAnimalSacrifice(executioner);
                
                if (victim?.RaceProps?.Humanlike == true)
                    SacrificeUtility.DoHumanSacrifice(executioner);
                
            }
            return true;
        }
    }
}
