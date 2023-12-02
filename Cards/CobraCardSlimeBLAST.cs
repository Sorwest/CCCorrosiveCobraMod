namespace CorrosiveCobra.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common)]
    public class CobraCardSlimeBLAST : Card
    {
        public override string Name() => "SLIME BLAST!!";
        private int GetStatusAmount(State state)
        {
            int allStatusAmount = 0;
            if (state.route is Combat)
            {
                foreach (KeyValuePair<Status, int> currentStatus in state.ship.statusEffects)
                    if (currentStatus.Key != Status.shield && currentStatus.Key != Status.tempShield)
                        allStatusAmount += currentStatus.Value;
            }
            return allStatusAmount;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            string str1;

            result.cost = 3;
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_SlimeBlastSprite!.Id);
            if (!(state.route is Combat))
                str1 = "";
            else
                str1 = string.Format("{0}{1}{2}", " (<c=keyword>", this.GetDmg(state, 2 * GetStatusAmount(state)), "</c>)");
            result.description = string.Format(Loc.GetLocString(Manifest.CobraCardSlimeBLAST?.DescLocKey ?? throw new Exception("Missing card")), str1);
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AAttack aattack1 = new AAttack();
            aattack1.damage = GetDmg(s, 2 * GetStatusAmount(s));
            aattack1.targetPlayer = false;
            cardActionList1.Add(aattack1);
            result = cardActionList1;

            return result;
        }
    }
}
