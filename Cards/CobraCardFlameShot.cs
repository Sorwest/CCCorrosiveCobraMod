namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardFlameShot : Card
    {
        public override string Name() => "Flame Blast";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 0;
            //result.art = new Spr?((Spr)Manifest.CorrosiveCobra_FlameBlastSprite!.Id!);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardFlameShot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 2), 3);
                    break;
                case Upgrade.A:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardFlameShot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 2), 2);
                    break;
                case Upgrade.B:
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardFlameShot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 4), 6);
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
                    aattack1.damage = GetDmg(s, 2);
                    cardActionList1.Add(aattack1);
                    AAddCard aaddCard1 = new AAddCard();
                    TrashMiasma trashMiasma1 = new TrashMiasma();
                    aaddCard1.card = trashMiasma1;
                    aaddCard1.amount = 3;
                    aaddCard1.destination = CardDestination.Deck;
                    cardActionList1.Add(aaddCard1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 2);
                    cardActionList2.Add(aattack2);
                    AAddCard aaddCard2 = new AAddCard();
                    TrashMiasma trashMiasma2 = new TrashMiasma();
                    aaddCard2.card = trashMiasma2;
                    aaddCard2.amount = 2;
                    aaddCard2.destination = CardDestination.Discard;
                    cardActionList2.Add(aaddCard2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 4);
                    cardActionList3.Add(aattack3);
                    AAddCard aaddCard3 = new AAddCard();
                    TrashMiasma trashMiasma3 = new TrashMiasma();
                    aaddCard3.card = trashMiasma3;
                    aaddCard3.amount = 5;
                    aaddCard3.destination = CardDestination.Deck;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
