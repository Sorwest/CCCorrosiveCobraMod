using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
public class CobraArtifactFuelWalls : Artifact
{
    public override string Name() => "FUEL WALLS";
    public override void OnReceiveArtifact(State state)
    {
        state.GetCurrentQueue().Add((CardAction)new AAddCard()
        {
            amount = 3,
            card = (Card)new CobraCardFuelWall()
        });
    }
    public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
    {
        (Tooltip) new TTCard()
        {
            card = (Card) new CobraCardFuelWall()
        },
    };
}
