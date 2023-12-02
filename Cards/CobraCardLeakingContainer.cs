namespace CorrosiveCobra.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardLeakingContainer : Card
    {
        public override string Name() => "Leaking Container";
        private int GetHandTotal(State s)
        {
            int handTotal = 0;
            if (s.route is Combat route)
                handTotal = route.hand.Count - 1;
            if (upgrade == Upgrade.A)
                ++handTotal;
            return handTotal;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.floppable = true;
            result.retain = true;
            result.art = new Spr?(!flipped ? (Spr)Manifest.CorrosiveCobra_SplitTopSprite!.Id : (Spr)Manifest.CorrosiveCobra_SplitBottomSprite!.Id);
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 2;
                        result.exhaust = false;
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
                    cardActionList1.Add(new AVariableHint()
                    {
                        hand = true,
                        handAmount = GetHandTotal(s),
                        disabled = flipped,
                    });
                    AHurt ahurt1 = new AHurt();
                    ahurt1.hurtAmount = 3;
                    ahurt1.targetPlayer = true;
                    ahurt1.disabled = flipped;
                    cardActionList1.Add(ahurt1);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.corrode;
                    astatus1.statusAmount = GetHandTotal(s);
                    astatus1.xHint = new int?(1);
                    astatus1.disabled = flipped;
                    astatus1.omitFromTooltips = true;
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    astatus2.disabled = !flipped;
                    cardActionList1.Add(astatus2);
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 3);
                    aattack1.disabled = !flipped;
                    cardActionList1.Add(aattack1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    cardActionList2.Add(new AVariableHint()
                    {
                        hand = true,
                        handAmount = GetHandTotal(s),
                        disabled = flipped,
                    });
                    AHurt ahurt3 = new AHurt();
                    ahurt3.hurtAmount = 3;
                    ahurt3.targetPlayer = true;
                    ahurt3.disabled = flipped;
                    cardActionList2.Add(ahurt3);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = GetHandTotal(s);
                    astatus3.omitFromTooltips = true;
                    astatus3.xHint = new int?(1);
                    astatus3.disabled = flipped;
                    cardActionList2.Add(astatus3);
                    AStatus astatus4 = new AStatus();
                    AHurt ahurt4 = new AHurt();
                    ahurt4.hurtAmount = 2;
                    ahurt4.targetPlayer = true;
                    ahurt4.disabled = !flipped;
                    cardActionList2.Add(ahurt4);
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 6);
                    aattack2.disabled = !flipped;
                    cardActionList2.Add(aattack2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.heat;
                    astatus5.statusAmount = 10;
                    astatus5.targetPlayer = true;
                    astatus5.omitFromTooltips = true;
                    astatus5.disabled = flipped;
                    cardActionList3.Add(astatus5);
                    AStunShip astunship1 = new AStunShip();
                    astunship1.disabled = flipped;
                    cardActionList3.Add(astunship1);
                    AEndTurn aendturn1 = new AEndTurn();
                    aendturn1.disabled = flipped;
                    cardActionList3.Add(aendturn1);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.heat;
                    astatus6.statusAmount = 1;
                    astatus6.targetPlayer = true;
                    astatus6.disabled = !flipped;
                    cardActionList3.Add(astatus6);
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3);
                    aattack3.disabled = !flipped;
                    cardActionList3.Add(aattack3);
                    result = cardActionList3;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
