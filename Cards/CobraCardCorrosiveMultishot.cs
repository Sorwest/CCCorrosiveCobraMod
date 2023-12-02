namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardCorrosiveMultishot : Card
    {
        public override string Name() => "Corrosive Multishot﻿";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 2;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosiveMultishotSprite!.Id!);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.exhaust = true;
                    break;
                case Upgrade.A:
                    result.exhaust = true;
                    break;
                case Upgrade.B:
                    result.exhaust = false;
                    result.infinite = true;
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
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 0);
                    aattack1.status = Status.corrode;
                    aattack1.statusAmount = 1;
                    aattack1.targetPlayer = false;
                    cardActionList1.Add(aattack1);
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.corrode;
                    aattack2.statusAmount = 1;
                    aattack2.targetPlayer = false;
                    cardActionList1.Add(aattack2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 2);
                    aattack3.status = Status.corrode;
                    aattack3.statusAmount = 1;
                    aattack3.targetPlayer = false;
                    cardActionList2.Add(aattack3);
                    AAttack aattack4 = new AAttack();
                    aattack4.damage = GetDmg(s, 0);
                    aattack4.status = Status.corrode;
                    aattack4.statusAmount = 1;
                    aattack4.targetPlayer = false;
                    cardActionList2.Add(aattack4);
                    AAttack aattack5 = new AAttack();
                    aattack5.damage = GetDmg(s, 0);
                    aattack5.status = Status.corrode;
                    aattack5.statusAmount = 1;
                    aattack5.targetPlayer = false;
                    cardActionList2.Add(aattack5);
                    Actions.AStatus2 astatus2 = new Actions.AStatus2();
                    astatus2.status = Status.corrode;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    astatus2.SelfInflict = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack6 = new AAttack();
                    aattack6.damage = GetDmg(s, 1);
                    aattack6.status = Status.corrode;
                    aattack6.statusAmount = 1;
                    aattack6.targetPlayer = false;
                    cardActionList3.Add(aattack6);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.heat;
                    astatus3.statusAmount = 1;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
