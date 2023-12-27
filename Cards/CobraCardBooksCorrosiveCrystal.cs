namespace CorrosiveCobra.Cards
{
    // BOOKS CARDS
    [CardMeta(unreleased = true, deck = Deck.shard, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardBooksCorrosiveCrystal : Card
    {
        public override string Name() => "Corrosive Crystal";
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 0);
                    aattack1.status = new Status?(Status.corrode);
                    aattack1.statusAmount = 1;
                    aattack1.shardcost = new int?(2);
                    cardActionList1.Add(aattack1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = new Status?(Status.corrode);
                    aattack2.statusAmount = 1;
                    aattack2.shardcost = new int?(1);
                    cardActionList2.Add(aattack2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList2.Add(astatus1);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3);
                    aattack3.status = new Status?(Status.corrode);
                    aattack3.statusAmount = 1;
                    aattack3.shardcost = new int?(2);
                    cardActionList3.Add(aattack3);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList3.Add(astatus2);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id!);
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
    }
}