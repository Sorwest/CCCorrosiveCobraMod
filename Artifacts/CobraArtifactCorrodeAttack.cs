namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class CobraArtifactCorrodeAttack : Artifact
{
    public override string Name() => "ACID ARSENAL";
    public int count;
    private const int TRIGGER_POINT = 7;

    public override int? GetDisplayNumber(State s) => new int?(this.count);

    public override void OnPlayerPlayCard(
      int energyCost,
      Deck deck,
      Card card,
      State state,
      Combat combat,
      int handPosition,
      int handCount)
    {
        if ((int)deck == Manifest.CobraDeck!.Id)
        {
            ++this.count;
            this.Pulse();
        }
        if (this.count < TRIGGER_POINT)
            return;
        AAttack aattack1 = new AAttack();
        aattack1.damage = 0;
        aattack1.status = Status.corrode;
        aattack1.statusAmount = 1;
        aattack1.targetPlayer = false;
        combat.QueueImmediate(aattack1);
        this.count = 0;
        this.Pulse();
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrode", 1),
        };
        return tooltips;
    }
}
