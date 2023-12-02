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
                    result.Add(new AStatus()
                    {
                        status = Status.tempShield,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.A:
                    result.Add(new AAttack()
                    {
                        damage = GetDmg(s, 1),
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.B:
                    result.Add(new AStatus()
                    {
                        status = Status.tempShield,
                        statusAmount = 5,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    break;
            }
            return result;
        }
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 1,
                art = new Spr?((Spr)Manifest.CorrosiveCobra_BlockShotSprite!.Id),
                artTint = upgrade == Upgrade.A ? "40a4fc" : "e20fc2",
            };
        }
    }
}
