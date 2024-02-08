using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardStolenFueltank : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("StolenFueltank", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "StolenFueltank", "name"]).Localize
        });
    }
    public override string Name() => "Stolen Fueltank";
    public override CardData GetData(State state)
    {
        return new CardData()
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
                result = new()
                {
                    ModEntry.Instance.KokoroApi.ActionCosts.Make(
                        ModEntry.Instance.KokoroApi.ActionCosts.Cost(
                            ModEntry.Instance.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                target: IKokoroApi.IActionCostApi.StatusResourceTarget.EnemyWithOutgoingArrow,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new ADrawCard()
                        {
                            count = 3,
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
                                target: IKokoroApi.IActionCostApi.StatusResourceTarget.EnemyWithOutgoingArrow,
                                ModEntry.Instance.Sprites["HeatCostUnsatisfied"].Sprite,
                                ModEntry.Instance.Sprites["HeatCostSatisfied"].Sprite
                            ),
                            amount: 1
                        ),
                        new ADrawCard()
                        {
                            count = 3,
                        }
                    )
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    ModEntry.Instance.KokoroApi.ConditionalActions.Make(
                        ModEntry.Instance.KokoroApi.ConditionalActions.Equation(
                            ModEntry.Instance.KokoroApi.ConditionalActions.Status(Status.heat),
                            IKokoroApi.IConditionalActionApi.EquationOperator.GreaterThanOrEqual,
                            ModEntry.Instance.KokoroApi.ConditionalActions.Constant(2),
                            IKokoroApi.IConditionalActionApi.EquationStyle.State,
                            hideOperator: true
                        ),
                        new ADrawCard()
                        {
                            count = 5,
                        }
                    )
                };
                break;
        }
        return result;
    }
}
