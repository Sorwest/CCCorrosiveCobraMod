using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss }, unremovable = true)]
public class CobraArtifactOverdriveTanks : Artifact
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
        CobraCardLeakingContainer leakingContainer1 = new CobraCardLeakingContainer();
        leakingContainer1.temporaryOverride = true;
        aaddCard1.card = (Card)leakingContainer1;
        aaddCard1.destination = CardDestination.Hand;
        combat.QueueImmediate((CardAction)aaddCard1);
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card = new CobraCardLeakingContainer()
            }
        };
        return tooltips;
    }
}
