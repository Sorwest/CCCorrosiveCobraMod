namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimePeriArtifact : Artifact
{
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseDraw -= 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseDraw += 1;
    }
    public override void OnCombatStart(State state, Combat combat)
    {
        AStatus aStatus1 = new AStatus()
        {
            status = Status.powerdrive,
            statusAmount = 1,
            targetPlayer = true,
        };
        combat.QueueImmediate(aStatus1);
        this.Pulse();
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.powerdriveAlt")
        };
        return tooltips;
    }
}
