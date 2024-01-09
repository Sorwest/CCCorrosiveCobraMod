using Sorwest.CorrosiveCobra.Actions;

namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true)]
public class CobraCardSlimeBooksDuo : Card
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
        var duoStatus = (Status)(Manifest.CrystalTapStatus?.Id ?? throw new Exception("Missing CrystalTapStatus"));
        List<CardAction> result = new List<CardAction>
        {
            new AStatus()
            {
                status = duoStatus,
                statusAmount = 1,
                targetPlayer = true,
                shardcost = 1,
            }
        };
        return result;
    }
}