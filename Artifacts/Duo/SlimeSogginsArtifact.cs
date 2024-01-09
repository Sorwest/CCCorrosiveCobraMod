using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeSogginsArtifact : Artifact , ISmugHook
{
    public int counter;
    public int TRIGGER = 4;
    public override void OnReceiveArtifact(State state)
    {
        counter = 0;
    }
    public void OnCardBotchedBySmug(State state, Combat combat, Card card)
    {
        if (counter < 0 && counter != (-1 * TRIGGER))
            counter -= 1;
        if (counter == (-1 * TRIGGER))
        {
            var duoCard = new CobraCardSlimeSogginsDuoBotch();
            AAddCard aAddCard1 = new AAddCard()
            {
                card = duoCard,
                amount = 1,
            };
            combat.QueueImmediate(aAddCard1);
            this.Pulse();
            counter = 0;
        }
        else
            counter = 0;
    }
    public void OnCardDoubledBySmug(State state, Combat combat, Card card)
    {
        if (counter > 0 && counter != TRIGGER)
            counter += 1;
        if (counter == TRIGGER)
        {
            var duoCard = new CobraCardSlimeSogginsDuoDouble();
            AAddCard aAddCard1 = new AAddCard()
            {
                card = duoCard,
                amount = 1,
            };
            combat.QueueImmediate(aAddCard1);
            this.Pulse();
            counter = 0;
        }
        else
            counter = 0;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        if (counter != 0)
        {
            var tooltips = new List<Tooltip>();
            var textSmug = "";
            if (counter < 0)
                textSmug = string.Format("Will gain a card after botching {0} more times.", counter + TRIGGER);
            if (counter > 0)
                textSmug = string.Format("Will gain a card after botching {0} more times.", TRIGGER - counter);
            tooltips.Add(new TTText()
            {
                text = textSmug
            });
            return tooltips;
        };
        return null;
    }
}
