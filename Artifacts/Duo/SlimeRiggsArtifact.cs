using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeRiggsArtifact : Artifact
{
    public override void OnPlayerDeckShuffle(State state, Combat combat)
    {
        CobraCardSlimeRiggsDuo duoCard = new()
        {
            temporaryOverride = true
        };
        AAddCard aAddCard1 = new()
        {
            amount = 1,
            card = duoCard,
            destination = CardDestination.Deck,
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
                card = new CobraCardSlimeRiggsDuo()
            }
        };
        return tooltips;
    }
}
