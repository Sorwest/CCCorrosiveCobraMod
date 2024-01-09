namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased }, unremovable = true)]
public class CobraArtifactDummyHeat : Artifact
{
    public override string Name() => "COBRA MISC OVERHEAT";
    public int overheatTrigger;
    public override int? GetDisplayNumber(State s)
    {
        overheatTrigger = s.ship.heatTrigger;
        return overheatTrigger;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTText("CURRENT OVERHEAT TRIGGER : " + overheatTrigger),
        };
        return tooltips;
    }
}
