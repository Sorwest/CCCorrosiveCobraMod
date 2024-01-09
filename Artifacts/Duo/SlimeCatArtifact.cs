namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
public class SlimeCatArtifact : Artifact
{
    public bool triggered;
    public override Spr GetSprite()
    {
        Spr sprite = new Spr();
        if (triggered)
            sprite = (Spr)Manifest.SlimeCatArtifactSprite_Off!.Id!;
        else
            sprite = (Spr)Manifest.SlimeCatArtifactSprite!.Id!;
        return sprite;
    }
    public override void OnTurnEnd(State state, Combat combat)
    {
        if (state.ship.hull == 1 && !triggered)
        {
            AStatus aStatus1 = new AStatus()
            {
                status = Status.perfectShield,
                statusAmount = 1,
                targetPlayer = true,
            };
            combat.QueueImmediate(aStatus1);
            AStatus aStatus2 = new AStatus()
            {
                status = Status.corrode,
                statusAmount = 1,
                targetPlayer = false,
            };
            combat.QueueImmediate(aStatus2);
            triggered = true;
            this.Pulse();
        }
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.perfectShield", 1),
            new TTGlossary("status.corrodeAlt")
        };
        return tooltips;
    }
}
