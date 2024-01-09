using Sorwest.CorrosiveCobra.Actions;
using Sorwest.CorrosiveCobra.Cards;
namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeBooksArtifact : Artifact
{
    public override void OnTurnStart(State state, Combat combat)
    {
        bool flag = false;
        foreach (Card card in combat.hand)
        {
            if (card is CobraCardSlimeBooksDuo)
                flag = true;
        }
        if (flag)
            return;
        combat.Queue(new ASlimeBooksDuoDelay());
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card =  new CobraCardSlimeBooksDuo()
            },
        };
        return tooltips;
    }
}
