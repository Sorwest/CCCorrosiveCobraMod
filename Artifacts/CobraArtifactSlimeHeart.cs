namespace CorrosiveCobra.Artifacts
{
    [ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class CobraArtifactSlimeHeart : Artifact
    {
        public override string Name() => "SLIME HEART";
        public override void OnTurnStart(State state, Combat combat)
        {
            if (Manifest.EvolveStatus?.Id == null)
                return;
            if (combat.turn != 1)
                return;
            AStatus astatus1 = new AStatus();
            astatus1.status = (Status)Manifest.EvolveStatus.Id;
            astatus1.statusAmount = 1;
            astatus1.targetPlayer = true;
            combat.Queue(astatus1);
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary(Manifest.AEvolveStatus_Glossary?.Head ?? throw new Exception("Missing AIncomingCorrode_Glossary"), 1),
        };
    }
}
