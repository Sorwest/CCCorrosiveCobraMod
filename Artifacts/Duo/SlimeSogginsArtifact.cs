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
        if (counter > 0)
        {
            counter = 0;
            this.Pulse();
        }
        else if (counter <= 0)
        {
            counter -= 1;
            if (counter == (-1 * TRIGGER))
            {
                var duoCard = new CobraCardSlimeSogginsDuoBotch()
                {
                    temporaryOverride = true,
                    discount = -1
                };
                AAddCard aAddCard1 = new AAddCard()
                {
                    card = duoCard,
                    amount = 1,
                };
                combat.QueueImmediate(aAddCard1);
                this.Pulse();
                counter = 0;
            }
        }
    }
    public void OnCardDoubledBySmug(State state, Combat combat, Card card)
    {
        if (counter < 0)
        {
            counter = 0;
            this.Pulse();
        }
        else if (counter >= 0)
        {
            counter += 1;
            if (counter == TRIGGER)
            {
                var duoCard = new CobraCardSlimeSogginsDuoDouble()
                {
                    temporaryOverride = true,
                    discount = -1
                };
                AAddCard aAddCard1 = new AAddCard()
                {
                    card = duoCard,
                    amount = 1,
                };
                combat.QueueImmediate(aAddCard1);
                this.Pulse();
                counter = 0;
            }
        }
    }
    public override int? GetDisplayNumber(State s)
    {
        if (counter == 0)
            return null;
        return counter > 0 ? counter : -1 * counter;
    }
    public override Spr GetSprite()
    {
        Spr sprite = new Spr();
        if (counter <= 0)
            sprite = (Spr)Manifest.SlimeSogginsArtifactSprite!.Id!;
        else
            sprite = (Spr)Manifest.SlimeSogginsArtifactSprite_Off!.Id!;
        return sprite;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        if (counter != 0)
        {
            var tooltips = new List<Tooltip>();
            var textSmug = "Will gain a card after {0} <c=boldPink>{1} more times</c>.";
            if (counter < 0)
                textSmug = string.Format(textSmug, "botching", counter + TRIGGER);
            if (counter > 0)
                textSmug = string.Format(textSmug, "doubling", TRIGGER - counter);
            tooltips.Add(new TTText()
            {
                text = textSmug
            });
            return tooltips;
        };
        return null;
    }
}
