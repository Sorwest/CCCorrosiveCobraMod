namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardFuelEjection : Card
    {
        public override string Name() => "Fuel Ejection";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 1;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id!);
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 1;
                        result.exhaust = false;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_HeatSprite!.Id!);
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id!);
                        break;
                    }
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.heat,
                                statusAmount = 1
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.corrode,
                                statusAmount = 1
                            }
                        )
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.heat,
                                statusAmount = 3
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.corrode,
                                statusAmount = 1
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.heat,
                                statusAmount = 3
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.corrode,
                                statusAmount = 1
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
                            new AAttack()
                            {
                                damage = GetDmg(s, 0),
                                status = Status.corrode,
                                statusAmount = 2
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
