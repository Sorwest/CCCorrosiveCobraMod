using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.EventOnly })]
public class SlimeMaxArtifactReward : Artifact
{
    public override void OnReceiveArtifact(State state)
    {
        foreach (Artifact artifact in state.artifacts)
        {
            if (artifact.GetType() == typeof(SlimeMaxArtifact))
                artifact.OnRemoveArtifact(state);
        }
        state.artifacts.RemoveAll((Predicate<Artifact>)(r => r.GetType() == typeof(SlimeMaxArtifact)));
        this.Pulse();
    }
    public override void OnCombatStart(State state, Combat combat)
    {
        var duoCard = new CobraCardSlimeMaxDuoReward()
        {
            temporaryOverride = true,
        };
        AAddCard aAddCard1 = new AAddCard()
        {
            card = duoCard,
            amount = 1,
            destination = CardDestination.Hand,
        };
        combat.QueueImmediate(aAddCard1);
        this.Pulse();
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card =  new CobraCardSlimeMaxDuoReward(),
                showCardTraitTooltips = false,
            },
        };
        return tooltips;
    }
}
