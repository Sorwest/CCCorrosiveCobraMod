using Nickel;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactDissolvent : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("Dissolvent", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Boss],
                unremovable = true
            },
            Sprite = ModEntry.Instance.Sprites["DissolventSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Dissolvent", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Dissolvent", "description"]).Localize
        });
    }
    public bool TriggeredAlready = false;
    public override string Name() => "DISSOLVENT";
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseEnergy += 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseEnergy -= 1;
    }
    public override void OnTurnStart(State state, Combat combat)
    {
        if (TriggeredAlready)
            TriggeredAlready = false;
    }
    public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
    {
        if (TriggeredAlready)
            return;
        TriggeredAlready = true;
        combat.QueueImmediate(new AHurt()
        {
            hurtAmount = 2,
            hurtShieldsFirst = true,
            targetPlayer = true
        });
        Pulse();
    }
}
