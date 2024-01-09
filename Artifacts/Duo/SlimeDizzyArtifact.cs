namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeDizzyArtifact : Artifact
{
    public override void OnReceiveArtifact(State state)
    {
        state.ship.shieldMaxBase += 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.shieldMaxBase -= 1;
    }
    public override void OnPlayerLoseHull(State state, Combat combat, int amount)
    {
        if (state.ship.Get(Status.corrode) > 0)
        {
            AStatus aStatus1 = new AStatus();
            aStatus1.status = Status.shield;
            aStatus1.statusAmount = 2;
            aStatus1.targetPlayer = true;
            combat.QueueImmediate(aStatus1);
            this.Pulse();
        }
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrodeAlt"),
            new TTGlossary("status.shieldAlt")
        };
        return tooltips;
    }
}
