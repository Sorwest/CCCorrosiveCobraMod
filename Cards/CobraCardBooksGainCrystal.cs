namespace CorrosiveCobra.Cards
{
    [CardMeta(unreleased = true, deck = Deck.shard, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardBooksGainCrystal : Card
    {
        public override string Name() => "Fuel Freezing";
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
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = -1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.shard;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList1.Add(astatus2);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.heat;
                    aattack2.statusAmount = -1;
                    cardActionList2.Add(aattack2);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.heat;
                    astatus3.statusAmount = 1;
                    astatus3.targetPlayer = true;
                    cardActionList2.Add(astatus3);
                    AStatus astatus4 = new AStatus();
                    astatus4.status = Status.shard;
                    astatus4.statusAmount = 2;
                    astatus4.targetPlayer = true;
                    cardActionList2.Add(astatus4);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 2);
                    cardActionList3.Add(aattack3);
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.heat;
                    astatus5.statusAmount = 1;
                    astatus5.targetPlayer = true;
                    cardActionList3.Add(astatus5);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.shard;
                    astatus6.statusAmount = 1;
                    astatus6.targetPlayer = true;
                    cardActionList3.Add(astatus6);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
        public override CardData GetData(State state) => new CardData()
        {
            cost = 1,
            art = new Spr?((Spr)Manifest.CorrosiveCobra_CardBackgroud!.Id!),
        };
    }
}
