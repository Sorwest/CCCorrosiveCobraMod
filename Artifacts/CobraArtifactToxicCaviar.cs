namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class CobraArtifactToxicCaviar : Artifact
{
    public override string Name() => "TOXIC CAVIAR";
    public override void OnTurnStart(State state, Combat combat)
    {
        if (state.ship.Get(Status.corrode) == 0)
            return;
        AStatus astatus1 = new AStatus();
        astatus1.status = Status.corrode;
        astatus1.statusAmount = -1;
        astatus1.targetPlayer = true;
        combat.QueueImmediate(astatus1);
        AStatus astatus2 = new AStatus();
        astatus2.status = Status.corrode;
        astatus2.statusAmount = 2;
        astatus2.targetPlayer = false;
        combat.QueueImmediate(astatus2);
    }

    public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
    {
        (Tooltip) new TTGlossary("status.corrode", 2),
    };
}
