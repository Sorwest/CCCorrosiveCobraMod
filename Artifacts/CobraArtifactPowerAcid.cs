namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Boss })]
public class CobraArtifactPowerAcid : Artifact
{
    public int otherShipCorrode = 0;
    public override string Name() => "POWERACID";
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseDraw -= 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseDraw += 1;
    }
    public override void OnTurnEnd(State state, Combat combat)
    {
        if (combat.otherShip.Get(Status.corrode) > 0)
        {
            otherShipCorrode = combat.otherShip.Get(Status.corrode);
            ACorrodeDamage aCorrodeDamage = new ACorrodeDamage();
            aCorrodeDamage.targetPlayer = false;
            combat.QueueImmediate(aCorrodeDamage);
        }
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrode", otherShipCorrode),
        };
        return tooltips;
    }
}
