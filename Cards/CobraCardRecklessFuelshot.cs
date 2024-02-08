using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardRecklessFuelshot : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("RecklessFuelshot", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RecklessFuelshot", "name"]).Localize
        });
    }
    public override string Name() => "Reckless Fuel Shot";
    public override CardData GetData(State state)
    {
        int num = 0;
        int num2 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 3;
                num2 = 3;
                break;
            case Upgrade.A:
                num = 3;
                num2 = 2;
                break;
            case Upgrade.B:
                num = 4;
                num2 = 3;
                break;
        }
        return new()
        {
            cost = 1,
            art = ModEntry.Instance.Sprites["RecklessFuelshotSprite"].Sprite,
            description = ModEntry.Instance.Localizations.Localize(["card", "RecklessFuelshot", "description", upgrade.ToString()], new { Damage = GetDmg(state, num), Count = num2 })
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = 0;
        int num2 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 3;
                num2 = 1;
                break;
            case Upgrade.A:
                num = 3;
                num2 = 1;
                break;
            case Upgrade.B:
                num = 6;
                num2 = 2;
                break;
        };
        return new()
        {
            new AAttack()
            {
                damage = GetDmg(s, num)
            },
            new AAddCard()
            {
                card = new TrashFumes(),
                destination = upgrade == Upgrade.A ? CardDestination.Discard : CardDestination.Deck,
                amount = num2
            }
        };
    }
}
