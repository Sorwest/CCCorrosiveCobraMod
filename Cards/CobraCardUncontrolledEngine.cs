namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardUncontrolledEngines : Card
{
    public override string Name() => "Uncontrolled Engines";
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
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    Manifest.KokoroApi.ActionCosts.Make(
                        Manifest.KokoroApi.ActionCosts.Cost(
                            Manifest.KokoroApi.ActionCosts.StatusResource(
                                Status.heat,
                                (Spr)Manifest.HeatCostUnsatisfied!.Id!.Value,
                                (Spr)Manifest.HeatCostSatisfied!.Id!.Value
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
                    new AMove()
                    {
                        dir = 2,
                        isRandom = true,
                        targetPlayer = true,
                    }
                };
                result = cardActionList3;
                break;
        }
        return result;
    }
}
