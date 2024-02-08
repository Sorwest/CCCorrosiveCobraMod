using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardColorlessSlimeSummon : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeSummon", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = Deck.colorless,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeSummon", "name"]).Localize
        });
    }
    public override string Name() => "Dizzy?.EXE";

    public override CardData GetData(State state)
    {
        int count = upgrade == Upgrade.A ? 6 : 2;
        return new()
        {
            cost = 1,
            exhaust = true,
            artTint = "45e0ab",
            description = ModEntry.Instance.Localizations.Localize(["card", "SlimeSummon", "description", upgrade.ToString()], new { Amount = count })
        };
    }

    public override List<CardAction> GetActions(State s, Combat c)
    {
        switch (upgrade)
        {
            case Upgrade.None:
                return new()
                {
                    new ACardOffering()
                    {
                        amount = 2,
                        limitDeck = ModEntry.Instance.SlimeDeck.Deck,
                        makeAllCardsTemporary = true,
                        canSkip = false,
                        inCombat = true,
                        discount = -1,
                        dialogueSelector = ".slimeSummon"
                    }
                };
            case Upgrade.A:
                return new()
                {
                    new ACardOffering()
                    {
                        amount = 6,
                        limitDeck = ModEntry.Instance.SlimeDeck.Deck,
                        makeAllCardsTemporary = true,
                        canSkip = false,
                        inCombat = true,
                        discount = -1,
                        dialogueSelector = ".slimeSummon"
                    }
                };
            case Upgrade.B:
                return new()
                {
                    new ACardOffering()
                    {
                        amount = 2,
                        limitDeck = ModEntry.Instance.SlimeDeck.Deck,
                        makeAllCardsTemporary = true,
                        canSkip = false,
                        inCombat = true,
                        discount = -1,
                        dialogueSelector = ".slimeSummon"
                    },
                    new ACardOffering()
                    {
                        amount = 2,
                        limitDeck = ModEntry.Instance.SlimeDeck.Deck,
                        makeAllCardsTemporary = true,
                        canSkip = false,
                        inCombat = true,
                        discount = -1,
                    }
                };
            default:
                return new();
        }
    }
}
