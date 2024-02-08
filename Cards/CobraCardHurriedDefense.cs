using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardHurriedDefense : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("HurriedDefense", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "HurriedDefense", "name"]).Localize
        });
    }
    public override string Name() => "Hurried Defense";
    public override CardData GetData(State state)
    {
        return new CardData
        {
            cost = 1,
            art = ModEntry.Instance.Sprites["BlockShotSprite"].Sprite,
            artTint = upgrade == Upgrade.B ? "40a4fc" : "e20fc2",
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
                        new AStatus()
                        {
                            status = Status.tempShield,
                            statusAmount = 2,
                            targetPlayer = true
                        }
                    ),
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 2
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
                        new AStatus()
                        {
                            status = Status.tempShield,
                            statusAmount = 5,
                            targetPlayer = true
                        }
                    ),
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 2
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 2,
                        targetPlayer = true
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 1)
                    }
                };
                break;
        }
        return result;
    }
}
