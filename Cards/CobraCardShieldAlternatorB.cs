namespace CorrosiveCobra.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common)]
    public class CobraCardShieldAlternatorB : Card
    {
        public override string Name() => "Temp Shield Replica";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 1;
            result.exhaust = true;
            result.artTint = "e20fc2";
            result.description = Loc.GetLocString(Manifest.CobraCardShieldAlternatorB?.DescLocKey ?? throw new Exception("Missing card"));
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.tempShield;
            astatus1.statusAmount = 2;
            astatus1.targetPlayer = true;
            cardActionList1.Add(astatus1);
            AAddCard aaddCard1 = new AAddCard();
            CobraCardShieldAlternatorA shieldAlternatorA1 = new CobraCardShieldAlternatorA();
            shieldAlternatorA1.upgrade = Upgrade.None;
            shieldAlternatorA1.temporaryOverride = new bool?(true);
            shieldAlternatorA1.singleUseOverride = new bool?(true);
            aaddCard1.card = (Card)shieldAlternatorA1;
            aaddCard1.destination = CardDestination.Hand;
            cardActionList1.Add(aaddCard1);
            result = cardActionList1;
            return result;
        }
    }
}
