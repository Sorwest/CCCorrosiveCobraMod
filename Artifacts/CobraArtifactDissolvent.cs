namespace Sorwest.CorrosiveCobra.Artifacts;

[ArtifactMeta(pools = new ArtifactPool[] { ArtifactPool.Boss })]
public class CobraArtifactDissolvent : Artifact
{
    public bool TriggeredAlready = false;
    public override string Name() => "DISSOLVENT";
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseEnergy += 1;
    }
    public override void OnTurnStart(State state, Combat combat)
    {
        if (TriggeredAlready)
        {
            TriggeredAlready = false;
        }
    }
    public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
    {
        if (TriggeredAlready)
        {
            return;
        }
        TriggeredAlready = true;
        AHurt ahurt1 = new AHurt();
        ahurt1.hurtAmount = 2;
        ahurt1.hurtShieldsFirst = true;
        ahurt1.targetPlayer = true;
        combat.QueueImmediate(ahurt1);
    }
}
