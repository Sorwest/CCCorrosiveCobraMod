using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;

namespace Sorwest.CorrosiveCobra;
public partial class Manifest :
    IShipPartManifest,
    IShipManifest,
    IStartershipManifest,
    IArtifactManifest
{
    public void LoadManifest(IShipPartRegistry registry)
    {
        {
            CorrosiveCobra_Cannon = new ExternalPart("Sorwest.CorrosiveCobra.Parts.Cannon",
                new Part()
                {
                    active = true,
                    type = PType.cannon
                },
                CorrosiveCobra_CannonSprite ?? throw new Exception());
        }
        {
            CorrosiveCobra_MissileBay = new ExternalPart("Sorwest.CorrosiveCobra.Parts.MissileBay",
            new Part()
            {
                active = true,
                type = PType.missiles
            },
             CorrosiveCobra_MissileBaySprite ?? throw new Exception());
        }
        {
            CorrosiveCobra_Cockpit = new ExternalPart("Sorwest.CorrosiveCobra.Parts.Cockpit",
            new Part()
            {
                active = true,
                type = PType.cockpit
            },
             CorrosiveCobra_CockpitSprite ?? throw new Exception());
        }
        {
            CorrosiveCobra_Scaffolding = new ExternalPart("Sorwest.CorrosiveCobra.Parts.Scaffolding",
            new Part()
            {
                active = true,
                type = PType.empty
            },
             CorrosiveCobra_ScaffoldingSprite ?? throw new Exception());
        }
        {
            CorrosiveCobra_WingLeft = new ExternalPart("Sorwest.CorrosiveCobra.Parts.WingLeft",
            new Part()
            {
                active = true,
                type = PType.wing
            },
             CorrosiveCobra_WingLeftSprite ?? throw new Exception());
        }
        {
            CorrosiveCobra_WingRight = new ExternalPart("Sorwest.CorrosiveCobra.Parts.WingRight",
            new Part()
            {
                active = true,
                type = PType.wing,
                flip = true
            },
             CorrosiveCobra_WingLeftSprite ?? throw new Exception());
        }
        registry.RegisterPart(CorrosiveCobra_Cannon);
        registry.RegisterPart(CorrosiveCobra_MissileBay);
        registry.RegisterPart(CorrosiveCobra_Cockpit);
        registry.RegisterPart(CorrosiveCobra_Scaffolding);
        registry.RegisterPart(CorrosiveCobra_WingLeft);
        registry.RegisterPart(CorrosiveCobra_WingRight);
    }
    public void LoadManifest(IShipRegistry shipRegistry)
    {
        CorrosiveCobra_Main = new ExternalShip("Sorwest.CorrosiveCobra.CobraMain",
            new Ship()
            {
                baseDraw = 5,
                baseEnergy = 3,
                heatTrigger = 3,
                heatMin = 0,
                hull = 11,
                hullMax = 11,
                shieldMaxBase = 4,
            },
            new ExternalPart[] {
                CorrosiveCobra_WingLeft ?? throw new Exception(),
                CorrosiveCobra_Cannon ?? throw new Exception(),
                CorrosiveCobra_Cockpit ?? throw new Exception(),
                CorrosiveCobra_MissileBay ?? throw new Exception(),
                CorrosiveCobra_WingRight ?? throw new Exception(),
            },
            CorrosiveCobra_ChassisSprite ?? throw new Exception());
        shipRegistry.RegisterShip(CorrosiveCobra_Main);
    }
    public void LoadManifest(IStartershipRegistry registry)
    {
        CorrosiveCobra_StarterShip = new ExternalStarterShip("Sorwest.CorrosiveCobra.CobraStarter",
            CorrosiveCobra_Main ?? throw new Exception(),
            new ExternalCard[]
            {
                CobraCardCorrosionBlockStarter ?? throw new Exception(),
                CobraCardCorrosionStarter ?? throw new Exception(),
            },
            new ExternalArtifact[]{
                CobraArtifactUnstableTanks ?? throw new Exception(),
            },
            nativeStartingCards: new Type[]
            {
                new DodgeColorless().GetType(),
                new CannonColorless().GetType(),
            },
            nativeStartingArtifacts: new Type[]
            {
                new ShieldPrep().GetType()
            },
            exclusiveArtifacts: new ExternalArtifact[]
            {
                CobraArtifactUnstableTanks ?? throw new Exception(),
                CobraArtifactOverdriveTanks ?? throw new Exception(),
                CobraArtifactFuelWalls ?? throw new Exception(),
            });
        CorrosiveCobra_StarterShip.AddLocalisation("Corrosive Cobra", "A derelict from another timeline, the Cobra specializes in corrosion attacks. Beware the fuel leaks.");

        registry.RegisterStartership(CorrosiveCobra_StarterShip);
    }
}
