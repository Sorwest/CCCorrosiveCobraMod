using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeIsaacDuo : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeIsaacDuo", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                rarity = Rarity.common,
                deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeIsaacDuo", "name"]).Localize
        });
    }
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = 2,
            exhaust = true,
            retain = true,
            flippable = true
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new ACobraField(),
            new ADroneMove()
            {
                dir = 1,
            }
        };
    }
}