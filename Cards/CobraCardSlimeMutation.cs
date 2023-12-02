namespace CorrosiveCobra.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common)]
    public class CobraCardSlimeMutation : Card
    {
        public override string Name() => "Slime Mutation";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.cost = 2;
            result.exhaust = true;
            result.description = Loc.GetLocString(Manifest.CobraCardSlimeMutation?.DescLocKey ?? throw new Exception("Missing card"));
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AAddCard aaddCard1 = new AAddCard();
            aaddCard1.dialogueSelector = ".addedSlimeBLAST";
            CobraCardSlimeBLAST slimeBlast = new CobraCardSlimeBLAST();
            slimeBlast.upgrade = Upgrade.None;
            slimeBlast.temporaryOverride = new bool?(true);
            aaddCard1.card = (Card)slimeBlast;
            aaddCard1.destination = CardDestination.Discard;
            cardActionList1.Add(aaddCard1);
            result = cardActionList1;
            return result;
        }
    }
}
