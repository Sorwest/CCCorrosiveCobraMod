using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactFuelWalls : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("FuelWalls", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = Deck.colorless,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["FuelWallsSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FuelWalls", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FuelWalls", "description"]).Localize
        });
    }
    public override string Name() => "FUEL WALLS";
    public override void OnReceiveArtifact(State state)
    {
        state.GetCurrentQueue().Add(new AAddCard()
        {
            amount = 3,
            card = new CobraCardFuelWall()
        });
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card =  new CobraCardFuelWall()
            },
        };
        return tooltips;
    }
}
