using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactCorrodeAttack : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("CorrodeAttack", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["CorrodeAttackSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "CorrodeAttack", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "CorrodeAttack", "description"]).Localize
        });
    }
    public override string Name() => "ACID ARSENAL";
    public int count;
    private const int TRIGGER_POINT = 7;

    public override int? GetDisplayNumber(State s)
    {
        return count;
    }

    public override void OnPlayerPlayCard(
      int energyCost,
      Deck deck,
      Card card,
      State state,
      Combat combat,
      int handPosition,
      int handCount)
    {
        if (deck == ModEntry.Instance.SlimeDeck.Deck)
        {
            ++count;
            Pulse();
        }
        if (this.count < TRIGGER_POINT)
            return;
        AAttack aattack1 = new AAttack();
        aattack1.damage = 0;
        aattack1.status = Status.corrode;
        aattack1.statusAmount = 1;
        aattack1.targetPlayer = false;
        combat.QueueImmediate(aattack1);
        count = 0;
        Pulse();
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrode", 1),
        };
        return tooltips;
    }
}
