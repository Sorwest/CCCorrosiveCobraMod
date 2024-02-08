
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeDizzyArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeDizzyArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeDizzyArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeDizzyArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeDizzyArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeDizzyArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.dizzy });
    }
    public override void OnReceiveArtifact(State state)
    {
        state.ship.shieldMaxBase += 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.shieldMaxBase -= 1;
    }
    public override void OnPlayerLoseHull(State state, Combat combat, int amount)
    {
        if (state.ship.Get(ModEntry.Instance.OxidationStatus.Status) >= 5 || state.ship.Get(Status.corrode) > 0)
        {
            combat.QueueImmediate(new AStatus()
            {
                status = Status.shield,
                statusAmount = 2,
                targetPlayer = true
            });
            Pulse();
        }
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.corrodeAlt"),
            new TTGlossary("status.shieldAlt"),
            new CustomTTGlossary(
                CustomTTGlossary.GlossaryType.action,
                () => ModEntry.Instance.OxidationStatus.Configuration.Definition.icon,
                () => ModEntry.Instance.Localizations.Localize(["status", "OxidationStatus", "name"]),
                () => ModEntry.Instance.Localizations.Localize(["status", "OxidationStatus", "description"]),
                key: $"{ModEntry.Instance.Package.Manifest.UniqueName}::OxidationStatus"
            )
        };
        return tooltips;
    }
}