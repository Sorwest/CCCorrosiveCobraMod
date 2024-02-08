using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeRiggsDuo : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeRiggsDuo", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                rarity = Rarity.common,
                deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeRiggsDuo", "name"]).Localize
        });
    }
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = 0,
            exhaust = true
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AAttack()
            {
                damage = GetDmg(s, 1),
                fast = true
            },
            new ADrawCard()
            {
                count = 2
            }
        };
    }
}