using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardBooksCorrosiveCrystal : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("CorrosiveCrystal", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = Deck.shard,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = ModEntry.Instance.NoExtraCards,
                unreleased = ModEntry.Instance.NoExtraCards
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "CorrosiveCrystal", "name"]).Localize
        });
    }
    public override string Name() => "Corrosive Crystal";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        return new()
        {
            cost = upgrade == Upgrade.A ? 1 : 0,
            art = ModEntry.Instance.Sprites["CorrodeSprite"].Sprite
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new();
        switch (upgrade)
        {
            case Upgrade.None:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = Status.corrode,
                        statusAmount = 1,
                        shardcost = 2
                    },
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = Status.corrode,
                        statusAmount = 1,
                        shardcost = 2
                    },
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = Status.corrode,
                        statusAmount = 1,
                        shardcost = 1
                    },
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 2,
                        targetPlayer = true
                    }
                };
                break;
        }
        return result;
    }
}