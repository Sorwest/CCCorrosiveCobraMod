using Sorwest.CorrosiveCobra.Actions;

namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true)]
public class CobraCardSlimeIsaacDuo : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 2,
            exhaust = true,
            retain = true,
            flippable = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new List<CardAction>
        {
            new ACobraField(),
            new ADroneMove()
            {
                dir = 1,
            }
        };
        return result;
    }
}