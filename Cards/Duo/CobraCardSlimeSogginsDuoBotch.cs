namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true)]
public class CobraCardSlimeSogginsDuoBotch : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 1,
            exhaust = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new List<CardAction>
        {
            new ADrawCard()
            {
                count = 5,
            },
            new AStatus()
            {
                status = Status.heat,
                statusAmount = 2,
                targetPlayer = false,
            }
        };
        return result;
    }
}