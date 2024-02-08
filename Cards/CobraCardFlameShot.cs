using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardFlameShot : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("FlameShot", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FlameShot", "name"]).Localize
        });
    }
    public override string Name() => "Flame Shot";
    public override CardData GetData(State state)
    {
        int num = 0;
        int num2 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 2;
                num2 = 1;
                break;
            case Upgrade.A:
                num = 3;
                num2 = 1;
                break;
            case Upgrade.B:
                num = 5;
                num2 = 3;
                break;
        }
        return new()
        {
            cost = 0,
            description = ModEntry.Instance.Localizations.Localize(["card", "FlameShot", "description"], new { Damage = GetDmg(state, num), Count = num2 })
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = 0;
        int num2 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 2;
                num2 = 1;
                break;
            case Upgrade.A:
                num = 3;
                num2 = 1;
                break;
            case Upgrade.B:
                num = 5;
                num2 = 3;
                break;
        }
        return new()
        {
            new AAttack()
            {
                damage = GetDmg(s, num)
            },
            new AAddCard()
            {
                card = new TrashMiasma(),
                destination = CardDestination.Deck,
                amount = num2
            }
        };
    }
}
