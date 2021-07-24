using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace IdeologiesOfMadness
{
    public class ThoughtWorker_Precept_NoRecentHumanSacrifice : ThoughtWorker_Precept, IPreceptCompDescriptionArgs
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return Find.World.GetComponent<WorldComponent_SacrificeTracker>().TicksSinceLastHumanSacrifice > 960000;
        }

        public IEnumerable<NamedArgument> GetDescriptionArgs()
        {
            yield return 16.Named("SACRIFICEDHUMANREQUIREDINTERVAL");
            yield break;
        }

        public const int MinDaysSinceLastHumanSacrificeForThought = 16;
    }
}

