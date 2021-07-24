using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RimWorld;
using Verse;
using RimWorld.Planet;
using UnityEngine;
using Verse.AI;

namespace IdeologiesOfMadness
{
    public class WorldComponent_SacrificeTracker : WorldComponent
    {
        private const bool DebugMode = true;
        private int ticksSinceLastHumanSacrifice = 0;
        private int ticksSinceLastAnimalSacrifice = 0;
        public WorldComponent_SacrificeTracker(World world) : base(world) { }
        public int TicksSinceLastHumanSacrifice { get => ticksSinceLastHumanSacrifice; }
        public int TicksSinceLastAnimalSacrifice { get => ticksSinceLastAnimalSacrifice; }

        public override void WorldComponentTick()
        {
            base.WorldComponentTick();
            ticksSinceLastAnimalSacrifice++;
            ticksSinceLastHumanSacrifice++;
        }

        public void HumanSacrificed()
        {
            if (DebugMode)
            {
                Messages.Message("DEBUG :: Human Sacrifice Satiated", null, MessageTypeDefOf.PositiveEvent);
            }
            ticksSinceLastHumanSacrifice = 0;}
        public void AnimalSacrificed()
        {
            if (DebugMode)
            {
                Messages.Message("DEBUG :: Animal Sacrifice Satiated", null, MessageTypeDefOf.PositiveEvent);
            }
            ticksSinceLastAnimalSacrifice = 0;}
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref ticksSinceLastAnimalSacrifice, "ticksSinceLastAnimalSacrifice");
            Scribe_Values.Look(ref ticksSinceLastHumanSacrifice, "ticksSinceLastHumanSacrifice");
        }
    }
}

