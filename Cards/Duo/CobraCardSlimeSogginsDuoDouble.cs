namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true)]
public class CobraCardSlimeSogginsDuoDouble : Card
{
    public bool IsFrogProof = true;
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
            new AAttack()
            {
                damage = GetDmg(s, 5),
                status = Status.heat,
                statusAmount = 2,
            },
        };
        return result;
    }
}