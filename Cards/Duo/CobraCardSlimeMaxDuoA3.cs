using Sorwest.CorrosiveCobra.Artifacts;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeMaxDuoA3 : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeMaxDuoA3", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                rarity = Rarity.common,
                deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                unreleased = true,
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeMaxDuo", "A3", "name"]).Localize
        });
    }
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 3,
            exhaust = true,
            retain = true,
            description = ModEntry.Instance.Localizations.Localize(["card", "SlimeMaxDuo", "A3", "description"])
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
                omitFromTooltips = true
            },
        };
        return result;
    }
}