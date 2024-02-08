using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardTinkerWithTheTanks : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("TinkerWithTheTanks", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TinkerWithTheTanks", "name"]).Localize
        });
    }
    public override string Name() => "Tinker With The Tanks";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = 1,
            exhaust = true,
            art = ModEntry.Instance.Sprites["RepairsSprite"].Sprite,
            description = ModEntry.Instance.Localizations.Localize(["card", "TinkerWithTheTanks", "description", upgrade.ToString()])
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AHeal()
            {
                healAmount = 1,
                targetPlayer = true,
                canRunAfterKill = true
            },
            new APlayRandomCard()
            {
                fromSource = upgrade == Upgrade.None ? FromSource.Hand : (upgrade == Upgrade.A ? FromSource.Deck : FromSource.Discard)
            }
        };
    }
}