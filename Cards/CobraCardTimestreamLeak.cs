namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardTimestreamLeak : Card
    {
        public int value = 1;
        public int playedtwo = 0;
        public string goal = "";
        public override string Name() => "Timestream Leak";

        public override void AfterWasPlayed(State state, Combat c)
        {
            if (this.upgrade == Upgrade.B)
                return;
            if (this.playedtwo == 0)
            {
                this.playedtwo = 1;
                return;
            }
            playedtwo = 0;
            ++this.value;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.exhaust = true;
            if (!(state.route is Combat route2))
            {
                goal = "";
            }
            else
            {
                goal = "{0}/1";
                if (this.playedtwo == 1)
                    goal = string.Format("{0}{1}{2}", "<c=healing>", goal, "</c>");
                goal = string.Format(goal, this.playedtwo);
            }
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 4;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardTimestreamLeak?.DescLocKey ?? throw new Exception("Missing card")), this.value, this.goal);
                    break;
                case Upgrade.A:
                    result.cost = 3;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardTimestreamLeak?.DescLocKey ?? throw new Exception("Missing card")), this.value, this.goal);
                    break;
                case Upgrade.B:
                    result.cost = 1;
                    result.description = string.Format(Loc.GetLocString(Manifest.CobraCardTimestreamLeak?.DescBLocKey ?? throw new Exception("Missing card")), this.value);
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.corrode;
            astatus1.statusAmount = this.value;
            astatus1.targetPlayer = false;
            cardActionList1.Add(astatus1);
            result = cardActionList1;
            return result;
        }
    }
}
