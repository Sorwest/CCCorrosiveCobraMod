namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(unreleased = true, dontOffer = true)]
public class CobraCardSlimeMaxDuo1 : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 0,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var nextCard = new CobraCardSlimeMaxDuo2()
        {
            temporaryOverride = true,
        };
        List<CardAction> result = new List<CardAction>
        {
            new AAttack()
            {
                damage = GetDmg(s, 1),
                status = Status.heat,
                statusAmount = 1,
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