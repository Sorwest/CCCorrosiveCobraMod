using CobaltCoreModding.Definitions;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using Sorwest.CorrosiveCobra.Artifacts;
using Sorwest.CorrosiveCobra.Cards;
using HarmonyLib;
using System.Reflection;
using Microsoft.Extensions.Logging;

/* Many thanks to parchmentengineer and theirs armada mod, check them out!
 * (January 7th, 2024 NOTE: parchmentArmada mod is outdated and might crash unexpectedly)
 * https://github.com/parchmentEngineer/parchmentArmada/releases/
 * So many thanks to EWanderer's selfless dedication to making the Cobalt Core modding community THRIVE!! Check Arin and EWanderer's collab project!
 * https://github.com/Ewanderer/CCMod.JohannaTheTrucker/releases/
 * Cobalt Core modding community is where it is now thanks to Shockah's hard work and motivation. Be sure to check Shockah's mods, they're extremely fun and add such an incredible depth to the game it's unreal!!
 * https://github.com/Shockah/Cobalt-Core-Mods
 */

namespace Sorwest.CorrosiveCobra;
public partial class Manifest :
    ISpriteManifest,
    IManifest,
    IShipPartManifest,
    IShipManifest,
    ICharacterManifest,
    IAnimationManifest,
    IStartershipManifest,
    IArtifactManifest,
    ICardManifest,
    IDeckManifest,
    IStatusManifest,
    IGlossaryManifest,
    IStoryManifest,
    IModManifest
{
    public DirectoryInfo? ModRootFolder { get; set; }
    public DirectoryInfo? GameRootFolder { get; set; }
    public string Name => "Sorwest.CorrosiveCobra";
    internal static Manifest Instance { get; private set; } = null!;
    internal static IKokoroApi KokoroApi { get; private set; } = null!;
    internal IDuoArtifactsApi? DuoArtifactsApi { get; private set; } = null!;
    internal ISogginsApi? SogginsApi { get; private set; } = null!;
    public IEnumerable<DependencyEntry> Dependencies => new DependencyEntry[]
    {
        new DependencyEntry<IModManifest>("Shockah.Kokoro", ignoreIfMissing: false),
        new DependencyEntry<IModManifest>("Shockah.DuoArtifacts", ignoreIfMissing: true),
        new DependencyEntry<IModManifest>("Shockah.Soggins", ignoreIfMissing: true)
    };
    public ILogger? Logger { get; set; }
    public static System.Drawing.Color CorrosiveCobraColor => System.Drawing.Color.FromArgb(107, 255, 205);
    public static string CobraColor => string.Format("{0:X2}{1:X2}{2:X2}",
        (object)CorrosiveCobraColor.R,
        (object)CorrosiveCobraColor.G,
        (object)CorrosiveCobraColor.B.ToString("X2"));

    public static ExternalShip? CorrosiveCobra_Main { get; private set; }
    public static ExternalStarterShip? CorrosiveCobra_StarterShip { get; private set; }
    public static ExternalDeck? CobraDeck { get; private set; }
    public static ExternalDeck? CobraShipDeck { get; private set; }

    //character art sprites
    public static ExternalCharacter? CorrosiveCobra_Character { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterMini_Sprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterPortrait_Sprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterPanelFrame_Sprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterGameover_Sprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterSquint_Sprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CharacterCrystal_Sprite { get; private set; }

    //character animation sprites
    public static ExternalAnimation? CorrosiveCobra_Character_DefaultAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_MiniAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_GameoverAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkLaughAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkNeutralAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkSquintAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkSadAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkMadAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkDarkAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkPhoneAnimation { get; private set; }
    public static ExternalAnimation? CorrosiveCobra_Character_TalkNervousAnimation { get; private set; }
    public static List<ExternalSprite> TalkLaughSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkNeutralSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkSquintSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkSadSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkMadSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkDarkSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkPhoneSprites { get; private set; } = new List<ExternalSprite>();
    public static List<ExternalSprite> TalkNervousSprites { get; private set; } = new List<ExternalSprite>();

    //artifact sprites
    public static ExternalSprite? UnstableTanksSprite { get; private set; }
    public static ExternalSprite? OverdriveTanksSprite { get; private set; }
    public static ExternalSprite? SlimeHeartSprite { get; private set; }
    public static ExternalSprite? ToxicCaviarSprite { get; private set; }
    public static ExternalSprite? CorrodeAttackSprite { get; private set; }
    public static ExternalSprite? PowerAcidSprite { get; private set; }
    public static ExternalSprite? DissolventSprite { get; private set; }
    public static ExternalSprite? DummyHeatSprite { get; private set; }
    public static ExternalSprite? FuelWallsSprite { get; private set; }
    
    //duo artifact sprites
    public static ExternalSprite? SlimeDizzyArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeRiggsArtifactSprite { get; private set; }
    public static ExternalSprite? SlimePeriArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeIsaacArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeIsaacArtifactSprite_Off { get; private set; }
    public static ExternalSprite? SlimeDrakeArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeDrakeArtifactSprite_Off { get; private set; }
    public static ExternalSprite? SlimeMaxArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeMaxArtifactRewardSprite { get; private set; }
    public static ExternalSprite? SlimeBooksArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeCatArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeCatArtifactSprite_Off { get; private set; }

    //modded duo artifact sprites
    public static ExternalSprite? SlimeSogginsArtifactSprite { get; private set; }
    public static ExternalSprite? SlimeSogginsArtifactSprite_Off { get; private set; }

    //icon sprites
    public static ExternalSprite? HeatCostSatisfied { get; private set; }
    public static ExternalSprite? HeatCostUnsatisfied { get; private set; }
    public static ExternalSprite? CorrodeCostSatisfied { get; private set; }
    public static ExternalSprite? CorrodeCostUnsatisfied { get; private set; }
    public static ExternalSprite? IncomingCorrodeIcon { get; private set; }
    public static ExternalSprite? EvolveStatusSprite { get; private set; }
    public static ExternalSprite? HeatOutbreakStatusSprite { get; private set; }
    public static ExternalSprite? HeatControlStatusSprite { get; private set; }

    // duo icon sprites
    public static ExternalSprite? CobraFieldSprite { get; private set; }
    public static ExternalSprite? CrystalTapStatusSprite { get; private set; }

    //background art sprites
    public static ExternalSprite? CorrosiveCobra_CardBackgroud { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CorrodeSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CorrosionIgnitionSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_BoxHeatSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_Split3_2TopSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_Split3_2BottomSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_SplitHalfTopSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_SplitHalfBottomSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_SeekerCobraSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_FumeCannonSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_EvolveBackgroundSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_RecklessFuelshotSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CorrosiveMultishotSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_RepairsSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_SlimeBlastSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_BlockShotSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_HeatSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_GoatDroneSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CannonCardSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CorrosionBlockStarter { get; private set; }

    //ship parts sprites
    public static ExternalSprite? CorrosiveCobra_CannonSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_WingLeftSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_WingRightSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_MissileBaySprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_CockpitSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_ScaffoldingSprite { get; private set; }
    public static ExternalSprite? CorrosiveCobra_ChassisSprite { get; private set; }

    // card borders sprites
    public static ExternalSprite? BorderCobraBasic { get; private set; }
    public static ExternalSprite? BorderCobraCommon { get; private set; }

    //artifacts
    public static ExternalArtifact? CobraArtifactUnstableTanks { get; private set; }
    public static ExternalArtifact? CobraArtifactOverdriveTanks { get; private set; }
    public static ExternalArtifact? CobraArtifactSlimeHeart { get; private set; }
    public static ExternalArtifact? CobraArtifactToxicCaviar { get; private set; }
    public static ExternalArtifact? CobraArtifactCorrodeAttack { get; private set; }
    public static ExternalArtifact? CobraArtifactPowerAcid { get; private set; }
    public static ExternalArtifact? CobraArtifactDissolvent { get; private set; }
    public static ExternalArtifact? CobraArtifactDummyHeat { get; private set; }
    public static ExternalArtifact? CobraArtifactFuelWalls { get; private set; }

    //duo artifacts
    public static ExternalArtifact? SlimeDizzyArtifact { get; private set; }
    public static ExternalArtifact? SlimeRiggsArtifact { get; private set; }
    public static ExternalArtifact? SlimePeriArtifact { get; private set; }
    public static ExternalArtifact? SlimeIsaacArtifact { get; private set; }
    public static ExternalArtifact? SlimeDrakeArtifact { get; private set; }
    public static ExternalArtifact? SlimeMaxArtifact { get; private set; }
    public static ExternalArtifact? SlimeMaxArtifactReward { get; private set; }
    public static ExternalArtifact? SlimeBooksArtifact { get; private set; }
    public static ExternalArtifact? SlimeCatArtifact { get; private set; }

    //modded duo artifacts
    public static ExternalArtifact? SlimeSogginsArtifact { get; private set; }

    //cards
    public static ExternalCard? CobraCardCorrosionStarter { get; private set; }
    public static ExternalCard? CobraCardCorrosionBlockStarter { get; private set; }
    public static ExternalCard? CobraCardFuelWall { get; private set; }
    public static ExternalCard? CobraCardFuelEjection { get; private set; }
    public static ExternalCard? CobraCardTankThrow { get; private set; }
    public static ExternalCard? CobraCardHeatedEvade { get; private set; }
    public static ExternalCard? CobraCardHurriedDefense { get; private set; }
    public static ExternalCard? CobraCardLeakingContainer { get; private set; }
    public static ExternalCard? CobraCardBooksCorrosiveCrystal { get; private set; }
    public static ExternalCard? CobraCardBooksGainCrystal { get; private set; }
    public static ExternalCard? CobraCardColorlessSlimeSummon { get; private set; }
    public static ExternalCard? CobraCardCorrosionIgnition { get; private set; }
    public static ExternalCard? CobraCardSlimeShield { get; private set; }
    public static ExternalCard? CobraCardSlimeHeal { get; private set; }
    public static ExternalCard? CobraCardTinkerWithTheTanks { get; private set; }
    public static ExternalCard? CobraCardTimestreamLeak { get; private set; }
    public static ExternalCard? CobraCardCorrosiveMultishot { get; private set; }
    public static ExternalCard? CobraCardSlimeEvolution { get; private set; }
    public static ExternalCard? CobraCardSlimeMutation { get; private set; }
    public static ExternalCard? CobraCardSlimeBLAST { get; private set; }
    public static ExternalCard? CobraCardSlimeHug { get; private set; }
    public static ExternalCard? CobraCardRecklessFuelshot { get; private set; }
    public static ExternalCard? CobraCardColorlessAbsorbArtifact { get; private set; }
    public static ExternalCard? CobraCardEnginesOnFire { get; private set; }
    public static ExternalCard? CobraCardHeatHoarder { get; private set; }
    public static ExternalCard? CobraCardShieldAlternatorA { get; private set; }
    public static ExternalCard? CobraCardShieldAlternatorB { get; private set; }
    public static ExternalCard? CobraCardAcidicFlare { get; private set; }
    public static ExternalCard? CobraCardFlameShot { get; private set; }
    public static ExternalCard? CobraCardStolenFueltank { get; private set; }
    public static ExternalCard? CobraCardUncontrolledEngines { get; private set; }

    //duo cards
    public static ExternalCard? CobraCardSlimeRiggsDuo { get; private set; }
    public static ExternalCard? CobraCardSlimeIsaacDuo { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo1 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo2 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo3 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo4 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo5 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo6 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo7 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuo8 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuoA1 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuoA2 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuoA3 { get; private set; }
    public static ExternalCard? CobraCardSlimeMaxDuoReward { get; private set; }
    public static ExternalCard? CobraCardSlimeBooksDuo { get; private set; }

    //modded duo cards
    public static ExternalCard? CobraCardSlimeSogginsDuoBotch { get; private set; }
    public static ExternalCard? CobraCardSlimeSogginsDuoDouble { get; private set; }

    //ship parts
    public static ExternalPart? CorrosiveCobra_Cannon { get; private set; }
    public static ExternalPart? CorrosiveCobra_MissileBay { get; private set; }
    public static ExternalPart? CorrosiveCobra_Cockpit { get; private set; }
    public static ExternalPart? CorrosiveCobra_Scaffolding { get; private set; }
    public static ExternalPart? CorrosiveCobra_WingLeft { get; private set; }
    public static ExternalPart? CorrosiveCobra_WingRight { get; private set; }

    //statuses
    public static ExternalStatus? EvolveStatus { get; private set; }
    public static ExternalStatus? HeatOutbreakStatus { get; private set; }
    public static ExternalStatus? HeatControlStatus { get; private set; }

    //duo statuses
    public static ExternalStatus? CrystalTapStatus { get; private set; }

    //glossary
    public static ExternalGlossary? AIncomingCorrode_Glossary { get; private set; }
    public static ExternalGlossary? AEvolveStatus_Glossary { get; private set; }
    public static ExternalGlossary? ACobraField_Glossary { get; private set; }
    public void BootMod(IModLoaderContact contact)
    {
        Instance = this;
        KokoroApi = contact.GetApi<IKokoroApi>("Shockah.Kokoro")!;
        DuoArtifactsApi = contact.LoadedManifests.Any(m => m.Name == "Shockah.DuoArtifacts") ? contact.GetApi<IDuoArtifactsApi>("Shockah.DuoArtifacts") : null;
        SogginsApi = contact.LoadedManifests.Any(m => m.Name == "Shockah.Soggins") ? contact.GetApi<ISogginsApi>("Shockah.Soggins") : null;


        Harmony harmony = new("Sorwest.CorrosiveCobra.Harmony");

        harmony.Patch(
            original: typeof(Colors).GetMethod("LookupColor", BindingFlags.Static | BindingFlags.Public),
            prefix: new HarmonyMethod(typeof(PatchLogic).GetMethod("CobraLookupColor", BindingFlags.Static | BindingFlags.NonPublic))
        );
        harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Card), nameof(Card.OnDraw)),
            postfix: new HarmonyMethod(typeof(PatchLogic).GetMethod("EvolveOnDraw", BindingFlags.Static | BindingFlags.NonPublic))
        );
        harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.OnAfterTurn)),
            postfix: new HarmonyMethod(typeof(PatchLogic).GetMethod("HeatOutbreakTurnEnd", BindingFlags.Static | BindingFlags.NonPublic))
        );
        harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.OnAfterTurn)),
            prefix: new HarmonyMethod(typeof(PatchLogic).GetMethod("HeatControlTurnEnd", BindingFlags.Static | BindingFlags.NonPublic))
        );
        if (DuoArtifactsApi != null)
        {
            harmony.Patch(
                original: typeof(AStatus).GetMethod("Begin"),
                postfix: new HarmonyMethod(typeof(PatchLogic).GetMethod("SlimeDrakeArtifactPatch", BindingFlags.Static | BindingFlags.NonPublic))
            );
            harmony.Patch(
                original: typeof(Combat).GetMethod("TryPlayCard"),
                postfix: new HarmonyMethod(typeof(PatchLogic).GetMethod("CrystalTapStatusPatch", BindingFlags.Static | BindingFlags.NonPublic))
            );
            if (SogginsApi != null)
            {
                _ = new FrogproofManager();
            }
        }
    }
    void ISpriteManifest.LoadManifest(ISpriteRegistry artRegistry)
    {
        if (this.ModRootFolder == null)
            throw new Exception("Root Folder not set");

        //ship parts
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_CannonSprite.png"));
                CorrosiveCobra_CannonSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CannonSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CannonSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_WingLeftSprite.png"));
                CorrosiveCobra_WingLeftSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_WingLeftSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_WingLeftSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_MissileBaySprite.png"));
                CorrosiveCobra_MissileBaySprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_MissileBaySprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_MissileBaySprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_CockpitSprite.png"));
                CorrosiveCobra_CockpitSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CockpitSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CockpitSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_ScaffoldingSprite.png"));
                CorrosiveCobra_ScaffoldingSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_ScaffoldingSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_ScaffoldingSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_ChassisSprite.png"));
                CorrosiveCobra_ChassisSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_ChassisSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_ChassisSprite);
            }
        }
        //character sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterPortrait_Sprite.png"));
                CorrosiveCobra_CharacterPortrait_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterPortrait_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterPortrait_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterMini_Sprite.png"));
                CorrosiveCobra_CharacterMini_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterMini_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterMini_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterPanelFrame_Sprite.png"));
                CorrosiveCobra_CharacterPanelFrame_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterPanelFrame_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterPanelFrame_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterGameover_Sprite.png"));
                CorrosiveCobra_CharacterGameover_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterGameover_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterGameover_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterSquint_Sprite.png"));
                CorrosiveCobra_CharacterSquint_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterSquint_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterSquint_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterCrystal_Sprite.png"));
                CorrosiveCobra_CharacterCrystal_Sprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CharacterCrystal_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterCrystal_Sprite);
            }
        }
        //talk animations
        {
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_laugh");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkLaugh" + i, files[i]);
                    TalkLaughSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_neutral");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkNeutral" + i, files[i]);
                    TalkNeutralSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_squint");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkSquint" + i, files[i]));
                    TalkSquintSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_sad");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkSad" + i, files[i]));
                    TalkSadSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_mad");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkMad" + i, files[i]));
                    TalkMadSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_dark");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkDark" + i, files[i]));
                    TalkDarkSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_phone");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkPhone" + i, files[i]));
                    TalkPhoneSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_nervous");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("Sorwest.CorrosiveCobra.Character.DizzySlime.TalkNervous" + i, files[i]));
                    TalkNervousSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
        }
        //icon sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("HeatCostSatisfied.png"));
                HeatCostSatisfied = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.HeatCostSatisfied", new FileInfo(path));
                artRegistry.RegisterArt(HeatCostSatisfied);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("HeatCostUnsatisfied.png"));
                HeatCostUnsatisfied = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.HeatCostUnsatisfied", new FileInfo(path));
                artRegistry.RegisterArt(HeatCostUnsatisfied);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("CorrodeCostSatisfied.png"));
                CorrodeCostSatisfied = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrodeCostSatisfied", new FileInfo(path));
                artRegistry.RegisterArt(CorrodeCostSatisfied);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("CorrodeCostUnsatisfied.png"));
                CorrodeCostUnsatisfied = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrodeCostUnsatisfied", new FileInfo(path));
                artRegistry.RegisterArt(CorrodeCostUnsatisfied);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("IncomingCorrodeIcon.png"));
                IncomingCorrodeIcon = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.IncomingCorrodeIcon", new FileInfo(path));
                artRegistry.RegisterArt(IncomingCorrodeIcon);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("EvolveStatusSprite.png"));
                EvolveStatusSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.EvolveStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(EvolveStatusSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("HeatOutbreakStatusSprite.png"));
                HeatOutbreakStatusSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.HeatOutbreakStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(HeatOutbreakStatusSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", Path.GetFileName("HeatControlStatusSprite.png"));
                HeatControlStatusSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.HeatControlStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(HeatControlStatusSprite);
            }
        }
        //duo icon sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", "Duo", Path.GetFileName("CobraFieldSprite.png"));
                CobraFieldSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CobraFieldSprite", new FileInfo(path));
                artRegistry.RegisterArt(CobraFieldSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icons", "Duo", Path.GetFileName("CrystalTapStatusSprite.png"));
                CrystalTapStatusSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CrystalTapStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(CrystalTapStatusSprite);
            }
        }
        //artifact sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("UnstableTanksSprite.png"));
                UnstableTanksSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.UnstableTanksSprite", new FileInfo(path));
                artRegistry.RegisterArt(UnstableTanksSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("OverdriveTanksSprite.png"));
                OverdriveTanksSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.OverdriveTanksSprite", new FileInfo(path));
                artRegistry.RegisterArt(OverdriveTanksSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("FuelWallsSprite.png"));
                FuelWallsSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.FuelWallsSprite", new FileInfo(path));
                artRegistry.RegisterArt(FuelWallsSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("SlimeHeartSprite.png"));
                SlimeHeartSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeHeartSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeHeartSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("ToxicCaviarSprite.png"));
                ToxicCaviarSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.ToxicCaviarSprite", new FileInfo(path));
                artRegistry.RegisterArt(ToxicCaviarSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("CorrodeAttackSprite.png"));
                CorrodeAttackSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrodeAttackSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrodeAttackSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("PowerAcidSprite.png"));
                PowerAcidSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.PowerAcidSprite", new FileInfo(path));
                artRegistry.RegisterArt(PowerAcidSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("DissolventSprite.png"));
                DissolventSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.DissolventSprite", new FileInfo(path));
                artRegistry.RegisterArt(DissolventSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", Path.GetFileName("DummyHeatSprite.png"));
                DummyHeatSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.DummyHeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(DummyHeatSprite);
            }
        }
        //duo artifact sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeDizzyArtifactSprite.png"));
                SlimeDizzyArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeDizzyArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeDizzyArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeRiggsArtifactSprite.png"));
                SlimeRiggsArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeRiggsArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeRiggsArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimePeriArtifactSprite.png"));
                SlimePeriArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimePeriArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimePeriArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeIsaacArtifactSprite.png"));
                SlimeIsaacArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeIsaacArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeIsaacArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeIsaacArtifactSprite_Off.png"));
                SlimeIsaacArtifactSprite_Off = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeIsaacArtifactSprite_Off", new FileInfo(path));
                artRegistry.RegisterArt(SlimeIsaacArtifactSprite_Off);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeDrakeArtifactSprite.png"));
                SlimeDrakeArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeDrakeArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeDrakeArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeDrakeArtifactSprite_Off.png"));
                SlimeDrakeArtifactSprite_Off = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeDrakeArtifactSprite_Off", new FileInfo(path));
                artRegistry.RegisterArt(SlimeDrakeArtifactSprite_Off);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeMaxArtifactSprite.png"));
                SlimeMaxArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeMaxArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeMaxArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeMaxArtifactRewardSprite.png"));
                SlimeMaxArtifactRewardSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeMaxArtifactRewardSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeMaxArtifactRewardSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeBooksArtifactSprite.png"));
                SlimeBooksArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeBooksArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeBooksArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeCatArtifactSprite.png"));
                SlimeCatArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeCatArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeCatArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeCatArtifactSprite_Off.png"));
                SlimeCatArtifactSprite_Off = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeCatArtifactSprite_Off", new FileInfo(path));
                artRegistry.RegisterArt(SlimeCatArtifactSprite_Off);
            }
        }
        //modded artifact sprites
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeSogginsArtifactSprite.png"));
                SlimeSogginsArtifactSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeSogginsArtifactSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeSogginsArtifactSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifacts", "Duo", Path.GetFileName("SlimeSogginsArtifactSprite_Off.png"));
                SlimeSogginsArtifactSprite_Off = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.SlimeSogginsArtifactSprite_Off", new FileInfo(path));
                artRegistry.RegisterArt(SlimeSogginsArtifactSprite_Off);
            }
        }
        //card background
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CardBackgroud.png"));
                CorrosiveCobra_CardBackgroud = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CardBackgroud", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CardBackgroud);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrodeSprite.png"));
                CorrosiveCobra_CorrodeSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CorrodeSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrodeSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosionIgnitionSprite.png"));
                CorrosiveCobra_CorrosionIgnitionSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CorrosionIgnitionSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosionIgnitionSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_Split3_2TopSprite.png"));
                CorrosiveCobra_Split3_2TopSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_Split3_2TopSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_Split3_2TopSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_Split3_2BottomSprite.png"));
                CorrosiveCobra_Split3_2BottomSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_Split3_2BottomSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_Split3_2BottomSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SplitHalfTopSprite.png"));
                CorrosiveCobra_SplitHalfTopSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_SplitHalfTopSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SplitHalfTopSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SplitHalfBottomSprite.png"));
                CorrosiveCobra_SplitHalfBottomSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_SplitHalfBottomSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SplitHalfBottomSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_BoxHeatSprite.png"));
                CorrosiveCobra_BoxHeatSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_BoxHeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_BoxHeatSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SeekerCobraSprite.png"));
                CorrosiveCobra_SeekerCobraSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_SeekerCobraSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SeekerCobraSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_FumeCannonSprite.png"));
                CorrosiveCobra_FumeCannonSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_FumeCannonSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_FumeCannonSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_EvolveBackgroundSprite.png"));
                CorrosiveCobra_EvolveBackgroundSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_EvolveBackgroundSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_EvolveBackgroundSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SlimeBlastSprite.png"));
                CorrosiveCobra_SlimeBlastSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_SlimeBlastSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SlimeBlastSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_RecklessFuelshotSprite.png"));
                CorrosiveCobra_RecklessFuelshotSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_RecklessFuelshotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_RecklessFuelshotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosiveMultishotSprite.png"));
                CorrosiveCobra_CorrosiveMultishotSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CorrosiveMultishotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosiveMultishotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_RepairsSprite.png"));
                CorrosiveCobra_RepairsSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_RepairsSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_RepairsSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_BlockShotSprite.png"));
                CorrosiveCobra_BlockShotSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_BlockShotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_BlockShotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_HeatSprite.png"));
                CorrosiveCobra_HeatSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_HeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_HeatSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_GoatDroneSprite.png"));
                CorrosiveCobra_GoatDroneSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_GoatDroneSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_GoatDroneSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CannonCardSprite.png"));
                CorrosiveCobra_CannonCardSprite = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CannonCardSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CannonCardSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosionBlockStarter.png"));
                CorrosiveCobra_CorrosionBlockStarter = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.CorrosiveCobra_CorrosionBlockStarter", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosionBlockStarter);
            }
        }
        //card border
        {
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBorder", Path.GetFileName("BorderCobraBasic.png"));
                BorderCobraBasic = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.BorderCobraBasic", new FileInfo(path));
                artRegistry.RegisterArt(BorderCobraBasic);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBorder", Path.GetFileName("BorderCobraCommon.png"));
                BorderCobraCommon = new ExternalSprite("Sorwest.CorrosiveCobra.sprites.BorderCobraCommon", new FileInfo(path));
                artRegistry.RegisterArt(BorderCobraCommon);
            }
        }
    }
    public void LoadManifest(IDeckRegistry registry)
    {
        var card_DefaultArt = CorrosiveCobra_CardBackgroud ?? throw new Exception();
        var borderCobraDeckSprite = BorderCobraCommon ?? throw new Exception();
        var borderCobraShipDeckSprite = BorderCobraBasic ?? throw new Exception();
        CobraDeck = new ExternalDeck(
            "Sorwest.CorrosiveCobra.CobraDeck",
            CorrosiveCobraColor,
            System.Drawing.Color.Black,
            card_DefaultArt,
            borderCobraDeckSprite,
            null);
        registry.RegisterDeck(Manifest.CobraDeck);
        CobraShipDeck = new ExternalDeck(
            "Sorwest.CorrosiveCobra.CobraShipDeck",
            CorrosiveCobraColor,
            System.Drawing.Color.Black,
            card_DefaultArt,
            borderCobraShipDeckSprite,
            null);
        registry.RegisterDeck(Manifest.CobraShipDeck);
    }
    void IGlossaryManifest.LoadManifest(IGlossaryRegisty registry)
    {
        AIncomingCorrode_Glossary = new ExternalGlossary("Sorwest.CorrosiveCobra.Glossary.AIncomingCorrode", "CorrosiveCobraIncomingCorrodeGlossary", false, ExternalGlossary.GlossayType.action, IncomingCorrodeIcon ?? throw new Exception("Missing IncomingCorrode Icon"));
        AIncomingCorrode_Glossary.AddLocalisation("en", "Recoil Corrode", "<c=hurt>Apply to self</c> <c=keyword>{0}</c> <c=status>Corrode</c>.", null);
        registry.RegisterGlossary(AIncomingCorrode_Glossary);

        AEvolveStatus_Glossary = new ExternalGlossary("Sorwest.CorrosiveCobra.Glossary.AEvolveStatus", "CorrosiveCobraEvolveStatusGlossary", false, ExternalGlossary.GlossayType.action, EvolveStatusSprite ?? throw new Exception("Missing EvolveStatus Icon"));
        AEvolveStatus_Glossary.AddLocalisation("en", "Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.", null);
        registry.RegisterGlossary(AEvolveStatus_Glossary);

        ACobraField_Glossary = new ExternalGlossary("Sorwest.CorrosiveCobra.Glossary.ACobraField", "CorrosiveCobraCobraFieldGlossary", false, ExternalGlossary.GlossayType.action, CobraFieldSprite ?? throw new Exception("Missing CobraFieldSprite Icon"));
        ACobraField_Glossary.AddLocalisation("en", "Cobra Field", "Instantly turn every <c=midrow>object in the midrow</c> into <c=drone>Corrode missiles</c> aimed at the enemy.", null);
        registry.RegisterGlossary(ACobraField_Glossary);

    }
    public void LoadManifest(IStatusRegistry registry)
    {
        {
            EvolveStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.EvolveStatus", true, CorrosiveCobraColor, null, EvolveStatusSprite ?? throw new Exception("MissingSprite"), true);
            
            EvolveStatus.AddLocalisation("Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.");
            
            registry.RegisterStatus(EvolveStatus);
        }
        {
            HeatOutbreakStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.HeatOutbreakStatus", false, CorrosiveCobraColor, null, HeatOutbreakStatusSprite ?? throw new Exception("MissingSprite"), true);
            
            HeatOutbreakStatus.AddLocalisation("Heat Outbreak", "At the end of turn, this ship is dealt {0} damage per <c=status>heat</c> it has.");
            
            registry.RegisterStatus(HeatOutbreakStatus);
        }
        {
            HeatControlStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.HeatControlStatus", true, CorrosiveCobraColor, null, HeatControlStatusSprite ?? throw new Exception("MissingSprite"), true);
            
            HeatControlStatus.AddLocalisation("Heat Control", "At the end of turn, your overheat trigger increases by <c=keyword>1<c/> <c=healing>permanently</c>, <c=hurt>then decrease this by 1</c>.");
            
            registry.RegisterStatus(HeatControlStatus);
        }

        var harmony = new Harmony("Sorwest.CorrosiveCobra.DuoStatus");
        if (DuoArtifactsApi != null) RegisterDuoStatus(registry, harmony);
    }
    void RegisterDuoStatus(IStatusRegistry registry, Harmony harmony)
    {
        {
            CrystalTapStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.CrystalTapStatus", true, CorrosiveCobraColor, null, CrystalTapStatusSprite ?? throw new Exception("MissingSprite"), true);

            CrystalTapStatus.AddLocalisation("Crystal Tap", "The next card is played twice.");

            registry.RegisterStatus(CrystalTapStatus);
        }
    }
    void ICardManifest.LoadManifest(ICardRegistry registry)
    {
        var card_DefaultArt = CorrosiveCobra_CardBackgroud;

        // BOOKS CARDS
        {
            {
                CobraCardBooksCorrosiveCrystal = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardCorrosiveCrystal", typeof(CobraCardBooksCorrosiveCrystal), card_DefaultArt ?? throw new Exception("missing card_DefaultArt"), ExternalDeck.GetRaw((int)Deck.shard));

                CobraCardBooksCorrosiveCrystal.AddLocalisation("Corrosive Crystal");

                registry.RegisterCard(CobraCardBooksCorrosiveCrystal);
            }
            {
                CobraCardBooksGainCrystal = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardFuelFreezing", typeof(CobraCardBooksGainCrystal), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.shard));

                CobraCardBooksGainCrystal.AddLocalisation("Fuel Freezing"); 
                
                registry.RegisterCard(CobraCardBooksGainCrystal);
            }
        }
        // CAT CARDS
        {
            {
                CobraCardColorlessSlimeSummon = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardColorlessSlimeSummon", typeof(CobraCardColorlessSlimeSummon), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));

                CobraCardColorlessSlimeSummon.AddLocalisation("Dizzy?.EXE", "Add 1 of {0} <c=cardtrait>discount, temp</c> <c={1}>Dizzy?</c> cards to your hand.");
                
                registry.RegisterCard(CobraCardColorlessSlimeSummon);}
            {
                CobraCardColorlessAbsorbArtifact = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardColorlessAbsorbArtifact", typeof(CobraCardColorlessAbsorbArtifact), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                
                CobraCardColorlessAbsorbArtifact.AddLocalisation("Absorb Artifact", desc: "<c=hurt>Lose a random artifact</c>. <c=healing>Heal 10</c>.");
                
                registry.RegisterCard(CobraCardColorlessAbsorbArtifact);
            }
        }
        // CORROSIVE COBRA CARDS
        {
            {
                CobraCardCorrosionStarter = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardCorrosionStarter", typeof(CobraCardCorrosionStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));

                CobraCardCorrosionStarter.AddLocalisation("Corrosive Fuelshot");

                registry.RegisterCard(CobraCardCorrosionStarter);
            }
            {
                CobraCardCorrosionBlockStarter = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardCorrosionBlockStarter", typeof(CobraCardCorrosionBlockStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                
                CobraCardCorrosionBlockStarter.AddLocalisation("Basic Heat Protection");
            
                registry.RegisterCard(CobraCardCorrosionBlockStarter);
            }
            {
                CobraCardFuelWall = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardFuelWall", typeof(CobraCardFuelWall), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));

                CobraCardFuelWall.AddLocalisation("Adv. Heat Protection"); 
                
                registry.RegisterCard(CobraCardFuelWall);
            }
            {
                CobraCardLeakingContainer = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardLeakingContainer", typeof(CobraCardLeakingContainer), card_DefaultArt, CobraShipDeck);

                CobraCardLeakingContainer.AddLocalisation("Leaking Container"); 
                
                registry.RegisterCard(CobraCardLeakingContainer);
            }
        }
        // DIZZY SLIME CARDS
        {
            {
                CobraCardFuelEjection = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardFuelEjection", typeof(CobraCardFuelEjection), card_DefaultArt, CobraDeck);

                CobraCardFuelEjection.AddLocalisation("Fuel Ejection");
                
                registry.RegisterCard(CobraCardFuelEjection);
            }
            {
                CobraCardTankThrow = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardTankThrow", typeof(CobraCardTankThrow), card_DefaultArt, CobraDeck);

                CobraCardTankThrow.AddLocalisation("Tank Throw");

                registry.RegisterCard(CobraCardTankThrow);
            }
            {
                CobraCardHeatedEvade = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardHeatedEvade", typeof(CobraCardHeatedEvade), card_DefaultArt, CobraDeck);

                CobraCardHeatedEvade.AddLocalisation("Heated Evade");

                registry.RegisterCard(CobraCardHeatedEvade);
            }
            {
                CobraCardHurriedDefense = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardHurriedDefense", typeof(CobraCardHurriedDefense), card_DefaultArt, CobraDeck);

                CobraCardHurriedDefense.AddLocalisation("Hurried Defense");

                registry.RegisterCard(CobraCardHurriedDefense);
            }
            {
                CobraCardCorrosionIgnition = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardCorrosionIgnition", typeof(CobraCardCorrosionIgnition), card_DefaultArt, CobraDeck);

                CobraCardCorrosionIgnition.AddLocalisation("Corrosion Ignition"); 
                
                registry.RegisterCard(CobraCardCorrosionIgnition);
            }
            {
                CobraCardSlimeShield = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeShield", typeof(CobraCardSlimeShield), card_DefaultArt, CobraDeck);
                
                CobraCardSlimeShield.AddLocalisation("Slime Shield", desc: "Gain <c=keyword>2</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal </c> to your <c=keyword>draw pile</c>.", descA: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal A</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal B</c> to your <c=keyword>draw pile</c>.");

                registry.RegisterCard(CobraCardSlimeShield);
            }
            {
                CobraCardSlimeHeal = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeHeal", typeof(CobraCardSlimeHeal), card_DefaultArt, CobraDeck);
                
                CobraCardSlimeHeal.AddLocalisation("Slime Heal");
            
                registry.RegisterCard(CobraCardSlimeHeal);
            }
            {
                CobraCardTinkerWithTheTanks = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardTinkerWithTheTanks", typeof(CobraCardTinkerWithTheTanks), card_DefaultArt, CobraDeck);
                
                CobraCardTinkerWithTheTanks.AddLocalisation("Tinker With The Tanks", desc: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container</c>.", descA: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container A</c>.", descB: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container B</c>.");
                
                registry.RegisterCard(CobraCardTinkerWithTheTanks);
            }
            {
                CobraCardTimestreamLeak = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardTimestreamLeak", typeof(CobraCardTimestreamLeak), card_DefaultArt, CobraDeck);
                
                CobraCardTimestreamLeak.AddLocalisation("Timestream Leak", desc: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>. +1 for every second time ever played. {1}", descB: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>.");
            
                registry.RegisterCard(CobraCardTimestreamLeak);
            }
            {
                CobraCardCorrosiveMultishot = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardCorrosiveMultishot", typeof(CobraCardCorrosiveMultishot), card_DefaultArt, CobraDeck);
            
                CobraCardCorrosiveMultishot.AddLocalisation("Corrosive Multishot");
            
                registry.RegisterCard(CobraCardCorrosiveMultishot);
            }
            {
                CobraCardSlimeEvolution = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeEvolution", typeof(CobraCardSlimeEvolution), card_DefaultArt, CobraDeck);

                CobraCardSlimeEvolution.AddLocalisation("Slime Evolution", desc: "Put a <c=card>Slime Mutation</c> in your <c=keyword>discard pile</c>. Draw <c=keyword>1</c>.", descB: "Put a <c=card>Slime Mutation</c> in your <c=keyword>draw pile</c>. Draw <c=keyword>1</c>.");

                registry.RegisterCard(CobraCardSlimeEvolution);
            }
            {
                CobraCardSlimeMutation = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMutation", typeof(CobraCardSlimeMutation), card_DefaultArt, CobraDeck);

                CobraCardSlimeMutation.AddLocalisation("Slime Mutation", desc: "Put a <c=card>SLIME BLAST!!</c> in your <c=keyword>discard pile</c>.");
            
                registry.RegisterCard(CobraCardSlimeMutation);
            }
            {
                CobraCardSlimeBLAST = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeBLAST", typeof(CobraCardSlimeBLAST), card_DefaultArt, CobraDeck);

                CobraCardSlimeBLAST.AddLocalisation("SLIME BLAST!!", desc: "Attack.\nDmg = Double of all your statuses.{0}");

                registry.RegisterCard(CobraCardSlimeBLAST);
            }
            {
                CobraCardSlimeHug = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeHug", typeof(CobraCardSlimeHug), card_DefaultArt, CobraDeck);

                CobraCardSlimeHug.AddLocalisation("Slime Hug");

                registry.RegisterCard(CobraCardSlimeHug);
            }
            {
                CobraCardRecklessFuelshot = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardRecklessFuelshot", typeof(CobraCardRecklessFuelshot), card_DefaultArt, CobraDeck);
                
                CobraCardRecklessFuelshot.AddLocalisation("Reckless Fuelshot", desc: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>draw pile</c>.", descA: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>discard pile</c>.");

                registry.RegisterCard(CobraCardRecklessFuelshot);
            }
            {
                CobraCardEnginesOnFire = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardEnginesOnFire", typeof(CobraCardEnginesOnFire), card_DefaultArt, CobraDeck);
                
                CobraCardEnginesOnFire.AddLocalisation("Engines! On Fire!");

                registry.RegisterCard(CobraCardEnginesOnFire);
            }
            {
                CobraCardHeatHoarder = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardHeatHoarder", typeof(CobraCardHeatHoarder), card_DefaultArt, CobraDeck);
                
                CobraCardHeatHoarder.AddLocalisation("Heat Hoarder", desc: "Gain <c=keyword>{0}</c> <c=status>Heat Control</c>. Add {1} non-temp <c=card>Miasma</c> to your <c=keyword>draw pile</c>.");

                registry.RegisterCard(CobraCardHeatHoarder);
            }
            {
                CobraCardShieldAlternatorA = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardShieldAlternatorA", typeof(CobraCardShieldAlternatorA), card_DefaultArt, CobraDeck);
                
                CobraCardShieldAlternatorA.AddLocalisation("Shield Replica", desc: "Gain <c=keyword>2</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>2</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your hand.");
            
                registry.RegisterCard(CobraCardShieldAlternatorA);
            }
            {
                CobraCardShieldAlternatorB = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardShieldAlternatorB", typeof(CobraCardShieldAlternatorB), card_DefaultArt, CobraDeck);
                
                CobraCardShieldAlternatorB.AddLocalisation("Temp Shield Replica", desc: "Gain <c=keyword>3</c> <c=status>temp shield</c>.\nAdd a <c=card>Shield Replica</c> to your hand.");
            
                registry.RegisterCard(CobraCardShieldAlternatorB);
            }
            {
                CobraCardAcidicFlare = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardAcidicFlare", typeof(CobraCardAcidicFlare), card_DefaultArt, CobraDeck);
            
                CobraCardAcidicFlare.AddLocalisation("Acidic Flare", desc: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>.", descA: "Turn <c=redd>ALL</c> <c=status>corrode</c> into <c=status>heat</c>. Gain a <c=card>Corrosion Ignition A</c>.", descB: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>. Gain a <c=card>Corrosion Ignition B</c>.");
            
                registry.RegisterCard(CobraCardAcidicFlare);
            }
            {
                CobraCardFlameShot = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardFlameShot", typeof(CobraCardFlameShot), card_DefaultArt, CobraDeck);
                
                CobraCardFlameShot.AddLocalisation("Flame Blast", desc: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Miasma</c> to your <c=keyword>draw pile</c>.");
            
                registry.RegisterCard(CobraCardFlameShot);
            }
            {
                CobraCardStolenFueltank = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardStolenFueltank", typeof(CobraCardStolenFueltank), card_DefaultArt, CobraDeck);
                
                CobraCardStolenFueltank.AddLocalisation("Stolen Fueltank");
            
                registry.RegisterCard(CobraCardStolenFueltank);
            }
            {
                CobraCardUncontrolledEngines = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardUncontrolledEngines", typeof(CobraCardUncontrolledEngines), card_DefaultArt, CobraDeck);
                
                CobraCardUncontrolledEngines.AddLocalisation("Uncontrolled Engine");
            
                registry.RegisterCard(CobraCardUncontrolledEngines);
            }
        }
        var harmony = new Harmony("Sorwest.CorrosiveCobra.DuoCards");
        if (DuoArtifactsApi != null) RegisterDuoCards(registry, harmony);
    }
    void RegisterDuoCards(ICardRegistry registry, Harmony harmony)
    {
        var card_DefaultArt = CorrosiveCobra_CardBackgroud ?? throw new Exception("missing card_DefaultArt");
        var duoDeck = DuoArtifactsApi!.DuoArtifactDeck;
        //duo cards
        {
            {
                CobraCardSlimeRiggsDuo = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeRiggsDuo", typeof(CobraCardSlimeRiggsDuo), card_DefaultArt, duoDeck);

                CobraCardSlimeRiggsDuo.AddLocalisation("Cheese Tea");

                registry.RegisterCard(CobraCardSlimeRiggsDuo);
            }
            {
                CobraCardSlimeIsaacDuo = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeIsaacDuo", typeof(CobraCardSlimeIsaacDuo), card_DefaultArt, duoDeck);

                CobraCardSlimeIsaacDuo.AddLocalisation("Cobra Field");

                registry.RegisterCard(CobraCardSlimeIsaacDuo);
            }
            {
                CobraCardSlimeMaxDuo1 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo1", typeof(CobraCardSlimeMaxDuo1), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo1.AddLocalisation("UP Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo1);
            }
            {
                CobraCardSlimeMaxDuo2 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo2", typeof(CobraCardSlimeMaxDuo2), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo2.AddLocalisation("UP Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo2);
            }
            {
                CobraCardSlimeMaxDuo3 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo3", typeof(CobraCardSlimeMaxDuo3), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo3.AddLocalisation("DOWN Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo3);
            }
            {
                CobraCardSlimeMaxDuo4 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo4", typeof(CobraCardSlimeMaxDuo4), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo4.AddLocalisation("DOWN Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo4);
            }
            {
                CobraCardSlimeMaxDuo5 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo5", typeof(CobraCardSlimeMaxDuo5), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo5.AddLocalisation("LEFT Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo5);
            }
            {
                CobraCardSlimeMaxDuo6 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo6", typeof(CobraCardSlimeMaxDuo6), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo6.AddLocalisation("RIGHT Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo6);
            }
            {
                CobraCardSlimeMaxDuo7 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo7", typeof(CobraCardSlimeMaxDuo7), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo7.AddLocalisation("LEFT Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo7);
            }
            {
                CobraCardSlimeMaxDuo8 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuo8", typeof(CobraCardSlimeMaxDuo8), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuo8.AddLocalisation("RIGHT Button");

                registry.RegisterCard(CobraCardSlimeMaxDuo8);
            }
            {
                CobraCardSlimeMaxDuoA1 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuoA1", typeof(CobraCardSlimeMaxDuoA1), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuoA1.AddLocalisation("B Button");

                registry.RegisterCard(CobraCardSlimeMaxDuoA1);
            }
            {
                CobraCardSlimeMaxDuoA2 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuoA2", typeof(CobraCardSlimeMaxDuoA2), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuoA2.AddLocalisation("A Button");

                registry.RegisterCard(CobraCardSlimeMaxDuoA2);
            }
            {
                CobraCardSlimeMaxDuoA3 = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuoA3", typeof(CobraCardSlimeMaxDuoA3), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuoA3.AddLocalisation("START Button", desc: "Gain a special artifact and lose <c=status>KONAMI CODE</c>.");

                registry.RegisterCard(CobraCardSlimeMaxDuoA3);
            }
            {
                CobraCardSlimeMaxDuoReward = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeMaxDuoReward", typeof(CobraCardSlimeMaxDuoReward), card_DefaultArt, duoDeck);

                CobraCardSlimeMaxDuoReward.AddLocalisation("Cheat Sheet");

                registry.RegisterCard(CobraCardSlimeMaxDuoReward);
            }
            {
                CobraCardSlimeBooksDuo = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeBooksDuo", typeof(CobraCardSlimeBooksDuo), card_DefaultArt, duoDeck);

                CobraCardSlimeBooksDuo.AddLocalisation("Crystal Tap");

                registry.RegisterCard(CobraCardSlimeBooksDuo);
            }
        }
        //modded duo cards
        {
            if (SogginsApi != null)
            {
                {
                    CobraCardSlimeSogginsDuoBotch = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeSogginsDuoBotch", typeof(CobraCardSlimeSogginsDuoBotch), card_DefaultArt, duoDeck);

                    CobraCardSlimeSogginsDuoBotch.AddLocalisation("Toad on a Treadmill");

                    registry.RegisterCard(CobraCardSlimeSogginsDuoBotch);
                }
                {
                    CobraCardSlimeSogginsDuoDouble = new ExternalCard("Sorwest.CorrosiveCobra.CobraCardSlimeSogginsDuoDouble", typeof(CobraCardSlimeSogginsDuoDouble), card_DefaultArt, duoDeck);

                    CobraCardSlimeSogginsDuoDouble.AddLocalisation("Toad with a Gun");

                    registry.RegisterCard(CobraCardSlimeSogginsDuoDouble);
                }
            }
        }
    }
    public void LoadManifest(IArtifactRegistry registry)
    {
        // CORROSIVE COBRA ARTIFACTS
        {
            {
                CobraArtifactUnstableTanks = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactUnstableTanks",
                    typeof(CobraArtifactUnstableTanks),
                    UnstableTanksSprite ?? throw new Exception("missing UnstableTanks artifact sprite"));

                CobraArtifactUnstableTanks.AddLocalisation("UNSTABLE TANKS",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=downside>Gain 1 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(CobraArtifactUnstableTanks);
            }
            {
                CobraArtifactOverdriveTanks = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactOverdriveTanks",
                    typeof(CobraArtifactOverdriveTanks),
                    OverdriveTanksSprite ?? throw new Exception("missing OverdriveTanks artifact sprite"));

                CobraArtifactOverdriveTanks.AddLocalisation("OVERDRIVE TANKS",
                    "Replaces <c=artifact>UNSTABLE FUELTANKS</c>. Gain 2 extra <c=energy>ENERGY</c> every turn. <c=downside>Gain 2 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(CobraArtifactOverdriveTanks);
            }
            {
                CobraArtifactFuelWalls = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactFuelWalls",
                    typeof(CobraArtifactFuelWalls),
                    FuelWallsSprite ?? throw new Exception("missing FuelWalls artifact sprite"));

                CobraArtifactFuelWalls.AddLocalisation("FUEL WALLS", "(Corrosive Cobra-excluse artifact!)\nOn pickup, add 3 <c=card>Adv. Heat Protection</c> to your deck.");

                registry.RegisterArtifact(CobraArtifactFuelWalls);
            }
        }
        // SLIME ARTIFACTS
        {
            {
                CobraArtifactSlimeHeart = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactSlimeHeart",
                    typeof(CobraArtifactSlimeHeart),
                    SlimeHeartSprite ?? throw new Exception("missing SlimeHeart artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactSlimeHeart.AddLocalisation("SLIME HEART",
                    "Gain 1 <c=status>EVOLVE</c> at the start of your first turn of combat.");

                registry.RegisterArtifact(CobraArtifactSlimeHeart);
            }
            {
                CobraArtifactToxicCaviar = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactToxicCaviar",
                    typeof(CobraArtifactToxicCaviar),
                    ToxicCaviarSprite ?? throw new Exception("missing ToxicCaviar artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactToxicCaviar.AddLocalisation("TOXIC CAVIAR",
                    "Lose 1 <c=status>CORRODE</c> each turn. <c=healing>If you do</c>, the enemy gains <c=keyword>2</c>.");

                registry.RegisterArtifact(CobraArtifactToxicCaviar);
            }
            {
                CobraArtifactCorrodeAttack = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactCorrodeAttack",
                    typeof(CobraArtifactCorrodeAttack),
                    CorrodeAttackSprite ?? throw new Exception("missing CorrodeAttack artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactCorrodeAttack.AddLocalisation("ACID ARSENAL",
                    "Every 7 <c=goat>Dizzy?</c> cards played, fire for 1 <c=status>CORRODE</c>.");

                registry.RegisterArtifact(CobraArtifactCorrodeAttack);
            }
            {
                CobraArtifactPowerAcid = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactPowerAcid",
                    typeof(CobraArtifactPowerAcid),
                    PowerAcidSprite ?? throw new Exception("missing PowerAcid artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactPowerAcid.AddLocalisation("POWERACID",
                    "<c=downside>Draw 1 less card per turn</c>. At the end of your turn, the enemy triggers <c=status>CORRODE</c>.");

                registry.RegisterArtifact(CobraArtifactPowerAcid);
            }
            {
                CobraArtifactDissolvent = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactDissolvent",
                    typeof(CobraArtifactDissolvent),
                    DissolventSprite ?? throw new Exception("missing Dissolvent artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactDissolvent.AddLocalisation("DISSOLVENT",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=downside>The first time each turn you are dealt damage, you receive an extra 2 damage</c>.");

                registry.RegisterArtifact(CobraArtifactDissolvent);
            }
            {
                CobraArtifactDummyHeat = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.CobraArtifactDummyHeat",
                    typeof(CobraArtifactDummyHeat),
                    DummyHeatSprite ?? throw new Exception("missing DummyHeat artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactDummyHeat.AddLocalisation("MISC ARTIFACT", "<c=status>OVERHEAT TRIGGER</c>.");

                registry.RegisterArtifact(CobraArtifactDummyHeat);
            }
        }
        var harmony = new Harmony("Sorwest.CorrosiveCobra.DuoArtifacts");
        if (DuoArtifactsApi != null) RegisterDuoArtifacts(registry, harmony);
    }
    void RegisterDuoArtifacts(IArtifactRegistry registry, Harmony harmony)
    {
        var cobraDeck = (Deck)CobraDeck!.Id!.Value;
        var duoDeck = DuoArtifactsApi!.DuoArtifactDeck;
        // duo artifacts
        {
            {
                SlimeDizzyArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeDizzyArtifact",
                    typeof(SlimeDizzyArtifact),
                    SlimeDizzyArtifactSprite ?? throw new Exception("missing SlimeDizzyArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeDizzyArtifact.AddLocalisation("UNYIELDING ROOK", "Gain <c=keyword>+1 max shield</c>. Whenever you lose hull, <c=keyword>if you have any</c> <c=status>CORRODE</c>, gain 2 <c=status>SHIELD</c>.");
                registry.RegisterArtifact(SlimeDizzyArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeDizzyArtifact), new[] { cobraDeck, Deck.dizzy });
            }
            {
                SlimeRiggsArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeRiggsArtifact",
                    typeof(SlimeRiggsArtifact),
                    SlimeRiggsArtifactSprite ?? throw new Exception("missing SlimeRiggsArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeRiggsArtifact.AddLocalisation("CHEESE TEA", "Every time your discard pile is shuffled back into your draw pile, add a <c=card>Cheese Tea</c> to <c=keyword>your draw pile</c>.");
                registry.RegisterArtifact(SlimeRiggsArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeRiggsArtifact), new[] { cobraDeck, Deck.riggs });
            }
            {
                SlimePeriArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimePeriArtifact",
                    typeof(SlimePeriArtifact),
                    SlimePeriArtifactSprite ?? throw new Exception("missing SlimePeriArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimePeriArtifact.AddLocalisation("UP-TO-DATE PROTOCOL", "<c=downside>Draw 1 less card per turn</c>. At the start of combat, gain 1 <c=status>POWERDRIVE</c>.");
                registry.RegisterArtifact(SlimePeriArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimePeriArtifact), new[] { cobraDeck, Deck.peri });
            }
            {
                SlimeIsaacArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeIsaacArtifact",
                    typeof(SlimeIsaacArtifact),
                    SlimeIsaacArtifactSprite ?? throw new Exception("missing SlimeIsaacArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeIsaacArtifact.AddLocalisation("COBRA FIELD", "At the start of combat, add a <c=card>Cobra Field</c> to your hand. On the fifth turn of combat, gain 5 <c=status>DRONESHIFT</c>.");
                registry.RegisterArtifact(SlimeIsaacArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeIsaacArtifact), new[] { cobraDeck, Deck.goat });
            }
            {
                SlimeDrakeArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeDrakeArtifact",
                    typeof(SlimeDrakeArtifact),
                    SlimeDrakeArtifactSprite ?? throw new Exception("missing SlimeDrakeArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeDrakeArtifact.AddLocalisation("KITCHENWARE", "Whenever you gain heat while <c=downside>overheating</c>, fire for 1 <c=status>CORRODE</c>.");
                registry.RegisterArtifact(SlimeDrakeArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeDrakeArtifact), new[] { cobraDeck, Deck.eunice });
            }
            {
                SlimeMaxArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeMaxArtifact",
                    typeof(SlimeMaxArtifact),
                    SlimeMaxArtifactSprite ?? throw new Exception("missing SlimeMaxArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeMaxArtifact.AddLocalisation("KONAMI CODE", "At the start of combat, add an <c=card>UP Button</c> to your hand. <c=keyword>Play the last card of the sequence to gain a special artifact</c> <c=downside>and remove this one</c>.");
                registry.RegisterArtifact(SlimeMaxArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeMaxArtifact), new[] { cobraDeck, Deck.hacker });
            }
            {
                SlimeMaxArtifactReward = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeMaxArtifactReward",
                    typeof(SlimeMaxArtifactReward),
                    SlimeMaxArtifactRewardSprite ?? throw new Exception("missing SlimeMaxArtifactReward artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeMaxArtifactReward.AddLocalisation("CHEAT SHEET", "At the start of combat, add a <c=card>Cheat Sheet</c> to your hand.");
                registry.RegisterArtifact(SlimeMaxArtifactReward);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeMaxArtifactReward), new[] { cobraDeck, Deck.hacker });
            }
            {
                SlimeBooksArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeBooksArtifact",
                    typeof(SlimeBooksArtifact),
                    SlimeBooksArtifactSprite ?? throw new Exception("missing SlimeBooksArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeBooksArtifact.AddLocalisation("CRYSTAL TAP", "At the start of your turn, if you don't have a <c=card>Crystal Tap</c> in your hand, gain one.");
                registry.RegisterArtifact(SlimeBooksArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeBooksArtifact), new[] { cobraDeck, Deck.shard });
            }
            {
                SlimeCatArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeCatArtifact",
                    typeof(SlimeCatArtifact),
                    SlimeCatArtifactSprite ?? throw new Exception("missing SlimeCatArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeCatArtifact.AddLocalisation("TIME WACK", "The first time you end your turn with only 1 hull, gain 1 <c=status>PERFECT SHIELD</c> and the enemy gains 1 <c=status>CORRODE</c>. <c=downside>Once per combat</c>.");
                registry.RegisterArtifact(SlimeCatArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeCatArtifact), new[] { cobraDeck, Deck.catartifact });
            }
        }
        // modded duo artifacts
        {
            if (SogginsApi != null)
            {
                SlimeSogginsArtifact = new ExternalArtifact("Sorwest.CorrosiveCobra.Artifacts.SlimeSogginsArtifact",
                    typeof(SlimeSogginsArtifact),
                    SlimeSogginsArtifactSprite ?? throw new Exception("missing SlimeSogginsArtifact artifact sprite"),
                    ownerDeck: duoDeck);

                SlimeSogginsArtifact.AddLocalisation("TOAD GYM", "The forth time Soggins botches a card, gain a <c=card>Toad in a Treadmill</c>.\nThe forth time Soggins doubles a card, gain a <c=card>Toad with a Gun</c>.\n<c=downside>Reset this any time Soggins botches or doubles out of sequence</c>.");
                registry.RegisterArtifact(SlimeSogginsArtifact);

                DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeSogginsArtifact), new[] { cobraDeck, (Deck)SogginsApi!.SogginsDeck.Id!.Value });
            }
        }
    }
}