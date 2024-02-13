using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardBooksGainCrystal : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("FuelFreezing", new()
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FuelFreezing", "name"]).Localize
        });
    }
    public override string Name() => "Fuel Freezing";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = 1
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
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.heat,
                            statusAmount = 1
                        }
                    ),
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.shard,
                        statusAmount = 1,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.heat,
                            statusAmount = 1
                        }
                    ),
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.shard,
                        statusAmount = 2,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.heat,
                            statusAmount = -1
                        }
                    ),
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.shard,
                        statusAmount = 3,
                        targetPlayer = true
                    }
                };
                break;
        }
        return result;
    }
}
