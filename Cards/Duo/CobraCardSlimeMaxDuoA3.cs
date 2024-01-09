using Sorwest.CorrosiveCobra.Artifacts;
namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true, unreleased = true)]
public class CobraCardSlimeMaxDuoA3 : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 3,
            exhaust = true,
            retain = true,
            description = Loc.GetLocString(Manifest.CobraCardSlimeMaxDuoA3?.DescLocKey ?? throw new Exception("Missing card")),
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new List<CardAction>
        {
            new AAddArtifact()
            {
                artifact = new SlimeMaxArtifactReward(),
                canRunAfterKill = true,
                omitFromTooltips = true,
            },
        };
        return result;
    }
}