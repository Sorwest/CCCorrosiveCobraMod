namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardHeatHoarder : Card
    {
        public override string Name() => "Heat Hoarder";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.singleUse = true;
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 1;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardHeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 1, 2);
                    break;
                case Upgrade.A:
                    result.cost = 0;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardHeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 1, 2);
                    break;
                case Upgrade.B:
                    result.cost = 3;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardHeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 3, 3);
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            var heatcontrol_status = (Status)(Manifest.HeatControlStatus?.Id ?? throw new Exception("Missing HeatOutbreakStatus"));
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AStatus astatus1 = new AStatus();
                    astatus1.status = heatcontrol_status;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    AAddCard aaddCard1 = new AAddCard();
                    TrashMiasma trashMiasma1 = new TrashMiasma();
                    trashMiasma1.temporaryOverride = false;
                    aaddCard1.card = trashMiasma1;
                    aaddCard1.amount = 2;
                    aaddCard1.destination = CardDestination.Deck;
                    cardActionList1.Add(aaddCard1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AStatus astatus2 = new AStatus();
                    astatus2.status = heatcontrol_status;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    AAddCard aaddCard2 = new AAddCard();
                    TrashMiasma trashMiasma2 = new TrashMiasma();
                    trashMiasma2.temporaryOverride = false;
                    aaddCard2.card = trashMiasma2;
                    aaddCard2.amount = 2;
                    aaddCard2.destination = CardDestination.Deck;
                    cardActionList2.Add(aaddCard2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus3 = new AStatus();
                    astatus3.status = heatcontrol_status;
                    astatus3.statusAmount = 2;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    AAddCard aaddCard3 = new AAddCard();
                    TrashMiasma trashMiasma3 = new TrashMiasma();
                    trashMiasma3.temporaryOverride = false;
                    aaddCard3.card = trashMiasma3;
                    aaddCard3.amount = 3;
                    aaddCard3.destination = CardDestination.Deck;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
