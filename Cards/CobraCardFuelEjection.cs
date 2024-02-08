using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;
public class CobraCardFuelEjection : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("FuelEjection", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FuelEjection", "name"]).Localize
        });
    }
    public override string Name() => "Fuel Ejection";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.B ? 2 : 1,
            exhaust = upgrade == Upgrade.A ? false : true,
            art = upgrade == Upgrade.A ? ModEntry.Instance.Sprites["HeatSprite"].Sprite : ModEntry.Instance.Sprites["CorrodeSprite"].Sprite
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
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 7
                            ),
                            amount: 1
                        ),
                        new AStatus()
                        {
                            status = Status.heat,
                            statusAmount = 2,
                            targetPlayer = false
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 6
                            ),
                            amount: 2
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.corrode,
                            statusAmount = 1
                        }
                    )
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
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 7
                            ),
                            amount: 1
                        ),
                        new AStatus()
                        {
                            status = Status.heat,
                            statusAmount = 3,
                            targetPlayer = false
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 6
                            ),
                            amount: 2
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.corrode,
                            statusAmount = 1
                        }
                    ),
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
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 7
                            ),
                            amount: 1
                        ),
                        new AStatus()
                        {
                            status = Status.heat,
                            statusAmount = 2,
                            targetPlayer = false
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 6
                            ),
                            amount: 2
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.corrode,
                            statusAmount = 1
                        }
                    ),
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite,
                                iconWidth: 7
                            ),
                            amount: 1
                        ),
                        new AAttack()
                        {
                            damage = GetDmg(s, 0),
                            status = Status.corrode,
                            statusAmount = 1
                        }
                    )
                };
                break;
        }
        return result;
    }
}
