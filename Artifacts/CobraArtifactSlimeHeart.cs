using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactSlimeHeart : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeHeart", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeHeartSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeHeart", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeHeart", "description"]).Localize
        });
    }
    public override string Name() => "SLIME HEART";
    public override void OnTurnStart(State state, Combat combat)
    {
        if (combat.turn != 1)
            return;
        AStatus astatus1 = new AStatus();
        astatus1.status = ModEntry.Instance.EvolveStatus.Status;
        astatus1.statusAmount = 1;
        astatus1.targetPlayer = true;
        combat.Queue(astatus1);
    }
    public override List<Tooltip>? GetExtraTooltips()
    => StatusMeta.GetTooltips(ModEntry.Instance.EvolveStatus.Status, 1);
}
