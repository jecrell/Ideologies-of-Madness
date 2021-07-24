using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace IdeologiesOfMadness
{
    public class ThoughtWorker_Precept_NoRecentAnimalSacrifice : ThoughtWorker_Precept, IPreceptCompDescriptionArgs
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return Find.World.GetComponent<WorldComponent_SacrificeTracker>().TicksSinceLastAnimalSacrifice > 1080000;
        }

        public IEnumerable<NamedArgument> GetDescriptionArgs()
        {
            yield return 18.Named("SACRIFICEDANIMALREQUIREDINTERVAL");
            yield break;
        }

        public const int MinDaysSinceLastAnimalSacrificeForThought = 18;
    }
}

