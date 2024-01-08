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
    }
    public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
    {
        (Tooltip) new TTCard()
        {
            card = (Card) new Cards.CobraCardSlimeRiggsDuo()
        }
    };
}
