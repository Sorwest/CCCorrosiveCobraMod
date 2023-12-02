namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardRecklessFuelshot : Card
    {
        public override string Name() => "Reckless Fuelshot";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 1;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RecklessFuelshotSprite!.Id!);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardRecklessFuelshot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 3), 1);
                    break;
                case Upgrade.A:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardRecklessFuelshot?.DescALocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 3), 1);
                    break;
                case Upgrade.B:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardRecklessFuelshot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 6), 2);
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
                    aattack1.damage = GetDmg(s, 3);
                    cardActionList1.Add(aattack1);
                    AAddCard aaddCard1 = new AAddCard();
                    Toxic toxic1 = new Toxic();
                    aaddCard1.card = toxic1;
                    aaddCard1.amount = 1;
                    aaddCard1.destination = CardDestination.Deck;
                    cardActionList1.Add(aaddCard1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 3);
                    cardActionList2.Add(aattack2);
                    AAddCard aaddCard2 = new AAddCard();
                    Toxic toxic2 = new Toxic();
                    aaddCard2.card = toxic2;
                    aaddCard2.amount = 1;
                    aaddCard2.destination = CardDestination.Discard;
                    cardActionList2.Add(aaddCard2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 6);
                    cardActionList3.Add(aattack3);
                    AAddCard aaddCard3 = new AAddCard();
                    Toxic toxic3 = new Toxic();
                    aaddCard3.card = toxic3;
                    aaddCard3.amount = 2;
                    aaddCard3.destination = CardDestination.Deck;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
