using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardUncontrolledEngines : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("UncontrolledEngines", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "UncontrolledEngines", "name"]).Localize
        });
    }
    public override string Name() => "Uncontrolled Engines";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.A ? 0 : 1
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new();
        switch (upgrade)
        {
            case Upgrade.None:
                List<CardAction> cardActionList1 = new List<CardAction>
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
                        new AMove()
                        {
                            dir = 1,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AMove()
                        {
                            dir = 2,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    ),
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true,
                    }
                };
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>
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
                        new AMove()
                        {
                            dir = 4,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AStatus()
                        {
                            status = Status.heat,
                            statusAmount = 3,
                            targetPlayer = true,
                        }
                    ),
                };
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>
                {
                    new AMove()
                    {
                        dir = 1,
                        isRandom = true,
                        targetPlayer = true,
                    },
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AMove()
                        {
                            dir = 2,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AMove()
                        {
                            dir = 3,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new AMove()
                        {
                            dir = 4,
                            isRandom = true,
                            targetPlayer = true,
                        }
                    )
                };
                result = cardActionList3;
                break;
        }
        return result;
    }
}
