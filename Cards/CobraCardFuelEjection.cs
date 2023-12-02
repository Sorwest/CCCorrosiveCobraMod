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
                        result.cost = 2;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 2;
                        result.exhaust = false;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_HeatSprite!.Id);
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 3;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
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
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 0);
                    aattack1.status = Status.heat;
                    aattack1.statusAmount = 1;
                    cardActionList1.Add(aattack1);
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.corrode;
                    aattack2.statusAmount = 1;
                    cardActionList1.Add(aattack2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = -1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 0);
                    aattack3.status = Status.heat;
                    aattack3.statusAmount = 3;
                    cardActionList2.Add(aattack3);
                    AAttack aattack4 = new AAttack();
                    aattack4.damage = GetDmg(s, 0);
                    aattack4.status = Status.corrode;
                    aattack4.statusAmount = 1;
                    cardActionList2.Add(aattack4);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = -3;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack5 = new AAttack();
                    aattack5.damage = GetDmg(s, 0);
                    aattack5.status = Status.heat;
                    aattack5.statusAmount = 3;
                    cardActionList3.Add(aattack5);
                    AAttack aattack6 = new AAttack();
                    aattack6.damage = GetDmg(s, 0);
                    aattack6.status = Status.corrode;
                    aattack6.statusAmount = 3;
                    cardActionList3.Add(aattack6);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.heat;
                    astatus3.statusAmount = 2;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
