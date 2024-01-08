namespace Sorwest.CorrosiveCobra.Cards;

// BOOKS CARDS
[CardMeta(dontOffer = true)]
public class CobraCardSlimeRiggsDuo : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 0,
            exhaust = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new List<CardAction>
        {
            Manifest.KokoroApi.ActionCosts.Make(
                Manifest.KokoroApi.ActionCosts.Cost(
                    Manifest.KokoroApi.ActionCosts.StatusResource(
                        Status.corrode,
                        (Spr)Manifest.CorrodeCostUnsatisfied!.Id!.Value,
                        (Spr)Manifest.CorrodeCostSatisfied!.Id!.Value
                    ),
                    amount: 1
                ),
                new AStatus()
                {
                    status = Status.hermes,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ),
            new ADrawCard()
            {
                count = 2,
            }
        };
        return result;
    }
}