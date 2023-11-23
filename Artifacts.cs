using CorrosiveCobra.Cards;

namespace CorrosiveCobra.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.EventOnly }, unremovable = true)]
    public class UnstableTanks : Artifact
    {
        public override string Name() => "UNSTABLE FUELTANKS";
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 1;
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseEnergy -= 1;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            Combat combat1 = combat;
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.heat;
            astatus1.statusAmount = 1;
            astatus1.targetPlayer = true;
            astatus1.timer = 0.0;
            combat1.QueueImmediate((CardAction)astatus1);
            if (combat.turn != 1)
                return;
            AAddCard aaddCard1 = new AAddCard();
            LeakingContainer leakingContainer1 = new LeakingContainer();
            leakingContainer1.temporaryOverride = true;
            aaddCard1.card = (Card)leakingContainer1;
            aaddCard1.destination = CardDestination.Hand;
            combat.QueueImmediate((CardAction)aaddCard1);
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTCard()
            {
                card = (Card) new Cards.LeakingContainer()
            }
        };
    }


    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss }, unremovable = true)]
    public class OverdriveTanks : Artifact
    {
        public override string Name() => "OVERDRIVETANKS";
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 2;
            foreach (Artifact artifact in state.artifacts)
            {
                if (artifact.Name() == "UNSTABLE FUELTANKS")
                    artifact.OnRemoveArtifact(state);
            }
            state.artifacts.RemoveAll((Predicate<Artifact>)(r => r.Name() == "UNSTABLE FUELTANKS"));
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseEnergy -= 2;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            Combat combat1 = combat;
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.heat;
            astatus1.statusAmount = 2;
            astatus1.targetPlayer = true;
            astatus1.timer = 0.0;
            combat1.QueueImmediate((CardAction)astatus1);
            if (combat.turn != 1)
                return;
            AAddCard aaddCard1 = new AAddCard();
            LeakingContainer leakingContainer1 = new LeakingContainer();
            leakingContainer1.temporaryOverride = true;
            aaddCard1.card = (Card)leakingContainer1;
            aaddCard1.destination = CardDestination.Hand;
            combat.QueueImmediate((CardAction)aaddCard1);
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTCard()
            {
                card = (Card) new Cards.LeakingContainer()
            }
        };
    }


    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class SlimeHeart : Artifact
    {
        public override string Name() => "SLIME HEART";
        public override void OnTurnStart(State state, Combat combat)
        {
            if (Manifest.EvolveStatus?.Id == null)
                return;
            if (combat.turn != 1)
                return;
            AStatus astatus1 = new AStatus();
            astatus1.status = (Status)Manifest.EvolveStatus.Id;
            astatus1.statusAmount = 1;
            astatus1.targetPlayer = true;
            combat.QueueImmediate(astatus1);
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary(Manifest.AEvolveStatus_Glossary?.Head ?? throw new Exception("Missing AIncomingCorrode_Glossary"), 1),
        };
    }


    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class ToxicCaviar : Artifact
    {
        public override string Name() => "TOXIC CAVIAR";
        public override void OnTurnStart(State state, Combat combat)
        {
            if (state.ship.Get(Status.corrode) == 0)
                return;
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.corrode;
            astatus1.statusAmount = -1;
            astatus1.targetPlayer = true;
            combat.QueueImmediate(astatus1);
            AStatus astatus2 = new AStatus();
            astatus2.status = Status.corrode;
            astatus2.statusAmount = 1;
            astatus2.targetPlayer = false;
            combat.QueueImmediate(astatus2);
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.corrode", 2),
        };
    }


    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class CorrodeAttack : Artifact
    {
        public override string Name() => "ACID ARSENAL";
        public int count;
        private const int TRIGGER_POINT = 7;

        public override int? GetDisplayNumber(State s) => new int?(this.count);

        public override void OnPlayerPlayCard(
          int energyCost,
          Deck deck,
          Card card,
          State state,
          Combat combat,
          int handPosition,
          int handCount)
        {
            if (((int)deck) == Manifest.CobraDeck!.Id.Value)
            {
                ++this.count;
                this.Pulse();
            }
            if (this.count < TRIGGER_POINT)
                return;
            AAttack aattack1 = new AAttack();
            aattack1.damage = card.GetDmg(state, 0);
            aattack1.status = Status.corrode;
            aattack1.statusAmount = 1;
            aattack1.targetPlayer = false;
            combat.QueueImmediate(aattack1);
            this.count = 0;
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.corrode", 1),
        };
    }


    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class PowerAcid : Artifact
    {
        public int otherShipCorrode = 0;
        public override string Name() => "POWERACID";
        public override void OnTurnEnd(State state, Combat combat)
        {
            if (combat.otherShip.Get(Status.corrode) > 0)
            {
                otherShipCorrode = combat.otherShip.Get(Status.corrode);
                ACorrodeDamage aCorrodeDamage = new ACorrodeDamage();
                aCorrodeDamage.targetPlayer = false;
                combat.QueueImmediate(aCorrodeDamage);
            }
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.corrode", otherShipCorrode),
        };
    }


    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Boss })]
    public class Dissolvent : Artifact
    {
        public bool TriggeredAlready = false;
        public override string Name() => "DISSOLVENT";
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 1;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            if (TriggeredAlready)
            { 
                TriggeredAlready = false;
            }
        }
        public override void OnPlayerTakeNormalDamage(State state, Combat combat)
        {
            if (TriggeredAlready)
            {
                return;
            }
            TriggeredAlready = true;
            AHurt ahurt1 = new AHurt();
            ahurt1.hurtAmount = 2;
            ahurt1.hurtShieldsFirst = true;
            ahurt1.targetPlayer = true;
            combat.QueueImmediate(ahurt1);
        }
    }

}
