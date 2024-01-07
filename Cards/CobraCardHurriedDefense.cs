namespace CorrosiveCobra.Cards
{

    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardHurriedDefense : Card
    {
        public override string Name() => "Hurried Defense";
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
                            new AStatus()
                            {
                                status = Status.tempShield,
                                statusAmount = 2,
                                targetPlayer = true
                            }
                        )
                    };
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s, 1),
                        },
                        new AStatus()
                        {
                            status = Status.shield,
                            statusAmount = 2,
                            targetPlayer = true
                        }
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
                            new AStatus()
                            {
                                status = Status.tempShield,
                                statusAmount = 5,
                                targetPlayer = true
                            }
                        )
                    };
                    result = cardActionList3;
                    break;
            }
            return result;
        }
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 1,
                art = new Spr?((Spr)Manifest.CorrosiveCobra_BlockShotSprite!.Id!),
                artTint = upgrade == Upgrade.A ? "40a4fc" : "e20fc2",
            };
        }
    }
}
