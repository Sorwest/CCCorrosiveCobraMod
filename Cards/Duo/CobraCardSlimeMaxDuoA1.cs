namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(unreleased = true, dontOffer = true)]
public class CobraCardSlimeMaxDuoA1 : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 3,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var nextCard = new CobraCardSlimeMaxDuoA2()
        {
            temporaryOverride = true,
        };
        List<CardAction> result = new List<CardAction>
        {
            new AAttack
            {
                damage = GetDmg(s, 2),
                status = Status.heat,
                statusAmount = 1,
                piercing = true,
            },
            new AAddCard()
            {
                card = nextCard,
                amount = 1,
                destination = CardDestination.Deck,
                omitFromTooltips = true,
            },
            new ADrawCard()
            {
                count = 1,
            }
        };
        return result;
    }
}