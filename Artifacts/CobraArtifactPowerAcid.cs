using Nickel;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactPowerAcid : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("PowerAcid", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Boss],
                unremovable = true
            },
            Sprite = ModEntry.Instance.Sprites["PowerAcidSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "PowerAcid", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "PowerAcid", "description"]).Localize
        });
    }
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
        if (combat.otherShip.Get(Status.corrode) <= 0)
            return;
        combat.QueueImmediate(new ACorrodeDamage()
        {
            targetPlayer = false
        });
        Pulse();
    }
}
