namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true)]
public class CobraCardSlimeMaxDuoReward : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 1,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new List<CardAction>
        {
            new AStatus()
            {
                status = Status.boost,
                statusAmount = 3,
                targetPlayer = true,
            },
            new ADrawCard()
            {
                count = 1,
            }
        };
        return result;
    }
}