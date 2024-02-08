using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactToxicCaviar : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("ToxicCaviar", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["ToxicCaviarSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "ToxicCaviar", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "ToxicCaviar", "description"]).Localize
        });
    }
    public override string Name() => "TOXIC CAVIAR";
    public override void OnTurnStart(State state, Combat combat)
    {
        if (state.ship.Get(Status.corrode) <= 0)
            return;
        combat.QueueImmediate(new AStatus()
        {
            status = Status.corrode,
            statusAmount = -1,
            targetPlayer = true,
            timer = 0
        });
        combat.QueueImmediate(new AStatus()
        {
            status = Status.corrode,
            statusAmount = 2,
            targetPlayer = false
        });
    }
}
