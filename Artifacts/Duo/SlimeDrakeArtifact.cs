using HarmonyLib;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeDrakeArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeDrakeArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeDrakeArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeDrakeArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeDrakeArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeDrakeArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.eunice });

        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(SlimeDrakeArtifactPatch))
        );
    }
    public bool overheating = false;
    public override Spr GetSprite()
    {
        if (overheating)
            return ModEntry.Instance.Sprites["SlimeDrakeArtifactSprite"].Sprite;
        else
            return ModEntry.Instance.Sprites["SlimeDrakeArtifactSprite_Off"].Sprite;
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
    private static void SlimeDrakeArtifactPatch(
        AStatus __instance,
        State s,
        Combat c)
    {
        var slimedrakeArtifact = s.EnumerateAllArtifacts().OfType<SlimeDrakeArtifact>().FirstOrDefault();
        if (slimedrakeArtifact != null)
        {
            if (__instance.status == Status.heat && __instance.targetPlayer == true)
            {
                if (s.ship.heatTrigger == s.ship.Get(Status.heat) && !slimedrakeArtifact.overheating)
                {
                    slimedrakeArtifact.overheating = true;
                    slimedrakeArtifact.Pulse();
                }
                else if (s.ship.heatTrigger < s.ship.Get(Status.heat))
                {
                    c.QueueImmediate(new AAttack()
                    {
                        damage = 0,
                        status = Status.corrode,
                        statusAmount = 1
                    });
                    slimedrakeArtifact.Pulse();
                }
            }
        }
        return;
    }
}