using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardTimestreamLeak : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("TimestreamLeak", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TimestreamLeak", "name"]).Localize
        });
    }
    public int value = 0;
    public int playedtwo = 0;
    public override string Name() => "Timestream Leak";

    public override void AfterWasPlayed(State state, Combat c)
    {
        if (upgrade == Upgrade.B)
            return;
        if (playedtwo == 0)
        {
            playedtwo = 1;
            return;
        }
        playedtwo = 0;
        ++value;
    }
    public override CardData GetData(State state)
    {
        string goal = "";
        if (state.route is Combat)
        {
            goal = "{0}/1";
            if (playedtwo == 1)
                goal = string.Format("<c=healing>{0}</c>", goal);
            goal = string.Format(goal, playedtwo);
        }
        int num = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 4;
                break;
            case Upgrade.A:
                num = 3;
                break;
            case Upgrade.B:
                num = 2;
                break;
        }
        return new()
        {
            cost = num,
            exhaust = true,
            description = ModEntry.Instance.Localizations.Localize(["card", "TimestreamLeak", "description", upgrade.ToString()], new { Amount = value, Count = state.route is Combat ? goal : "" })
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AStatus()
            {
                status = Status.corrode,
                statusAmount = value,
                targetPlayer = false,
                dialogueSelector = ".TimestreamLeak"
            }
        };
    }
}
