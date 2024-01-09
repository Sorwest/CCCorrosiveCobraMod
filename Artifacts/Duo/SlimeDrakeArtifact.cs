namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeDrakeArtifact : Artifact
{
    //Effect is done in PatchLogic
    public bool overheating = false;
    public override Spr GetSprite()
    {
        Spr sprite = new Spr();
        if (overheating)
            sprite = (Spr)Manifest.SlimeDrakeArtifactSprite!.Id!;
        else
            sprite = (Spr)Manifest.SlimeDrakeArtifactSprite_Off!.Id!;
        return sprite;
    }
    public override void OnCombatEnd(State state)
    {
        if (overheating)
            overheating = false;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrodeAlt")
        };
        return tooltips;
    }
}
