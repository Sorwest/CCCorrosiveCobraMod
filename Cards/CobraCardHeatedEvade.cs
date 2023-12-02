namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardHeatedEvade : Card
    {
        public override string Name() => "Heated Evade";
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = upgrade == Upgrade.A ? 0 : 1,
                art = new Spr?((Spr)Manifest.CorrosiveCobra_BoxHeatSprite!.Id),
            };
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {

                case Upgrade.None:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.A:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.B:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 3,
                        isRandom = true,
                        targetPlayer = true
                    });
                    break;
            }
            return result;
        }
    }
}
