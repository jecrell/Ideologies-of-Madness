using System;
using System.Linq;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;

namespace IdeologiesOfMadness
{
    public static class SacrificeUtility
    {
        public static void DoHumanSacrifice(Pawn executioner)
        {
            if (ModsConfig.IdeologyActive)
            {
                Find.World.GetComponent<WorldComponent_SacrificeTracker>().HumanSacrificed();
                Find.HistoryEventsManager.RecordEvent(
                    new HistoryEvent(DefDatabase<HistoryEventDef>.GetNamed("ROM_SacrificedHuman"),
                    executioner.Named(HistoryEventArgsNames.Doer)), true);
            }
        }
        public static void DoAnimalSacrifice(Pawn executioner)
        {
            Find.World.GetComponent<WorldComponent_SacrificeTracker>().AnimalSacrificed();
            if (ModsConfig.IdeologyActive)
            {
                Find.HistoryEventsManager.RecordEvent(
                    new HistoryEvent(DefDatabase<HistoryEventDef>.GetNamed("ROM_SacrificedAnimal"),
                    executioner.Named(HistoryEventArgsNames.Doer)), true);
            }
        }
    }
}
