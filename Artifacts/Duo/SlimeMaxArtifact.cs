using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeMaxArtifact : Artifact
{
    public override void OnCombatStart(State state, Combat combat)
    {
        var duoCard = new CobraCardSlimeMaxDuo1()
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
}
