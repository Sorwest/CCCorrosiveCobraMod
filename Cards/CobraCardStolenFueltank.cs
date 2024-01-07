using Sorwest.CorrosiveCobra;
using static Sorwest.CorrosiveCobra.IKokoroApi.IActionCostApi;

namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardStolenFueltank : Card
    {
        public override string Name() => "Stolen Fueltank";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 1;
                    break;
                case Upgrade.A:
                    result.cost = 0;
                    break;
                case Upgrade.B:
                    result.cost = 1;
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>
                    {
                        Manifest.KokoroApi.ActionCosts.Make(
                            Manifest.KokoroApi.ActionCosts.Cost(
                                Manifest.KokoroApi.ActionCosts.StatusResource(
                                    Status.heat,
                                    target: StatusResourceTarget.EnemyWithOutgoingArrow,
                                    (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                    (Spr)Manifest.HeatCostSatisfied!.Id!.Value
                                ),
                                amount: 1
                            ),
                            new ADrawCard()
                            {
                                count = 3,
                            }
                        )
                    };
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>()
                    {
                        Manifest.KokoroApi.ActionCosts.Make(
                            Manifest.KokoroApi.ActionCosts.Cost(
                                Manifest.KokoroApi.ActionCosts.StatusResource(
                                    Status.heat,
                                    target: StatusResourceTarget.EnemyWithOutgoingArrow,
                                    (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                    (Spr)Manifest.HeatCostSatisfied!.Id!.Value
                                ),
                                amount: 1
                            ),
                            new ADrawCard()
                            {
                                count = 3,
                            }
                        )
                    };
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>()
                    {
                        Manifest.KokoroApi.ConditionalActions.Make(
                            Manifest.KokoroApi.ConditionalActions.Equation(
                                Manifest.KokoroApi.ConditionalActions.Status(Status.heat),
                                IKokoroApi.IConditionalActionApi.EquationOperator.GreaterThanOrEqual,
                                Manifest.KokoroApi.ConditionalActions.Constant(2),
                                IKokoroApi.IConditionalActionApi.EquationStyle.State,
                                hideOperator: true
                            ),
                            new ADrawCard()
                            {
                                count = 5,
                            }
                        )
                    };
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
