namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(unreleased = true, dontOffer = true)]
public class CobraCardSlimeMaxDuo5 : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 2,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var nextCard = new CobraCardSlimeMaxDuo6()
        {
            temporaryOverride = true,
        };
        List<CardAction> result = new List<CardAction>
        {
            new AMove()
            {
                dir = -2,
                targetPlayer = true,
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