namespace CorrosiveCobra.Actions
{
    public class AStatus2 : AStatus
    {
        public bool SelfInflict;

        public override List<Tooltip> GetTooltips(State s)
        {
            List<Tooltip> list = new List<Tooltip>();
            if (SelfInflict && status == Status.corrode)
            {
                list.Add(new TTGlossary(Manifest.AIncomingCorrode_Glossary?.Head ?? throw new Exception("Missing AIncomingCorrode_Glossary"), statusAmount));
            }
            list.AddRange(StatusMeta.GetTooltips(status, statusAmount));
            return list;
        }
        public override Icon? GetIcon(State s)
        {
            Icon icon;
            int? number = ((mode == AStatusMode.Set) ? null : new int?(statusAmount));
            if (status == Status.corrode && SelfInflict)
                icon = new Icon((Spr)Manifest.IncomingCorrodeIcon!.Id.Value, statusAmount, Colors.textMain);
            else
                icon = new Icon(DB.statuses[status].icon, number, Colors.textMain);
            return icon;
        }
    }
}
