namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardCorrosionIgnition﻿ : Card
    {
        public override string Name() => "Corrosion Ignition﻿";
        private int GetHeatAmt(State s)
        {
            int heatAmt = 0;
            if (s.route is Combat)
                heatAmt = s.ship.Get(Status.heat);
            return heatAmt;
        }
        private int GetCorrodeAmt(State s)
        {
            int corrodeAmt = 0;
            if (s.route is Combat)
                corrodeAmt = s.ship.Get(Status.corrode);
            return corrodeAmt;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 3;
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 0;
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 0;
                        break;
                    }
            }
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosionIgnition﻿Sprite!.Id!);
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    cardActionList1.Add(new AVariableHint()
                    {
                        status = Status.heat,
                        secondStatus = Status.corrode,
                    });
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, GetHeatAmt(s) + GetCorrodeAmt(s));
                    aattack1.xHint = new int?(1);
                    cardActionList1.Add(aattack1);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.corrode;
                    astatus1.statusAmount = 0;
                    astatus1.mode = AStatusMode.Set;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    cardActionList2.Add(new AVariableHint()
                    {
                        status = Status.heat,
                    });
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, GetHeatAmt(s));
                    aattack2.xHint = new int?(1);
                    cardActionList2.Add(aattack2);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 0;
                    astatus2.mode = AStatusMode.Set;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    cardActionList3.Add(new AVariableHint()
                    {
                        status = Status.corrode,
                    });
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3 * GetCorrodeAmt(s));
                    aattack3.xHint = new int?(3);
                    cardActionList3.Add(aattack3);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = 3;
                    astatus3.mode = AStatusMode.Set;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
