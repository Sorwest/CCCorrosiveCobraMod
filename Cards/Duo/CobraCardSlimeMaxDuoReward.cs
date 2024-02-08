using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeMaxDuoReward : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeMaxDuoReward", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                rarity = Rarity.common,
                deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                unreleased = true,
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeMaxDuo", "Reward", "name"]).Localize
        });
    }
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 1,
            exhaust = true,
            retain = true
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